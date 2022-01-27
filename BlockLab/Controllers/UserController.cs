namespace BlockLab.Controllers;

[Authorize(Roles = "admins")]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary> Все пользователи </summary>
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users;
        var models = await users.Select(u => new UserWebModel
        {
            Id = u.Id,
            SurName = u.SurName,
            FirstName = u.FirstName,
            Patronymic = u.Patronymic,
            UserName = u.UserName,
            Email = u.Email,
            BirthDay = u.Birthday,
            Age = DateTime.Today.Year - u.Birthday.Year,
            RolesNames = _userManager.GetRolesAsync(u).Result,
        }).ToArrayAsync();
        foreach (var m in models)
        {
            m.RolesNames = m.RolesNames.Select(r => _roleManager.Roles.First(rr => rr.Name == r).Description);
        }
        return View(models);
    }

    /// <summary> Создание нового пользователя </summary>
    public IActionResult Create()
    {
        var allRoles = _roleManager.Roles.ToList();
        var model = new UserEditWebModel
        {
            AllRoles = allRoles,
        };
        return View("Edit", model);
    }

    /// <summary> Редактирование пользователя </summary>
    public async Task<IActionResult> Edit(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            var model = new UserEditWebModel();
            return View(model);
        }
        if (await _userManager.FindByIdAsync(id) is { } user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var model = new UserEditWebModel
            {
                Id = user.Id,
                SurName = user.SurName,
                FirstName = user.FirstName,
                Patronymic = user.Patronymic,
                UserName = user.UserName,
                Email = user.Email,
                Birthday = user.Birthday,
                UserRoles = userRoles,
                AllRoles = allRoles,
            };
            return View(model);
        }
        return NotFound();
    }
    /// <summary> Редактирование пользователя </summary>
    /// <param name="model">Модель пользователя</param>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserEditWebModel model, List<string> roles)
    {
        if (model is null)
            return BadRequest();
        if (!ModelState.IsValid)
            return View(model);
        var user = await _userManager.FindByIdAsync(model.Id);
        IdentityResult result;
        if (user is null)
        {
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError(nameof(model.Password), "Нужно обязательно ввести новый пароль пользователя");
                return View(model);
            }
            var newUser = new User
            {
                SurName = model.SurName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                UserName = model.UserName,
                Email = model.Email,
                Birthday = model.Birthday,
            };
            result = await _userManager.CreateAsync(newUser, model.Password);
            await _userManager.AddToRolesAsync(newUser, roles);
        }
        else
        {
            user.SurName = model.SurName;
            user.FirstName = model.FirstName;
            user.Patronymic = model.Patronymic;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Birthday = model.Birthday;
            result = await _userManager.UpdateAsync(user);
            if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
            {
                await _userManager.RemovePasswordAsync(user);
                result = await _userManager.AddPasswordAsync(user, model.Password);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
        }
        if (result.Succeeded)
        {

            return RedirectToAction("Index", "User");
        }
        foreach (var err in result.Errors)
            ModelState.AddModelError("", err.Description);
        return View(model);
    }

    /// <summary> Удалить пользователя </summary>
    /// <param name="id">Идентификатор пользователя</param>
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        var u = await _userManager.FindByIdAsync(id);
        if (u is null)
            return NotFound();
        var model = new UserWebModel
        {
            Id = u.Id,
            SurName = u.SurName,
            FirstName = u.FirstName,
            Patronymic = u.Patronymic,
            UserName = u.UserName,
            Email = u.Email,
            BirthDay = u.Birthday,
            Age = DateTime.Today.Year - u.Birthday.Year,
            RolesNames = _userManager.GetRolesAsync(u).Result,
        };
        model.RolesNames = model.RolesNames.Select(r => _roleManager.Roles.First(rr => rr.Name == r).Description);
        return View(model);
    }
    /// <summary> Подтверждение удаления пользователя </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        var user = await _userManager.FindByIdAsync(id);
        if (user.UserName == "admin")
            return BadRequest();
        await _userManager.DeleteAsync(user);
        return RedirectToAction("Index", "User");
    }

    #region WebAPI

    [AllowAnonymous]
    public async Task<IActionResult> IsNameFree(string UserName, string Id)
    {
        var user = await _userManager.FindByNameAsync(UserName);
        var result = (user is null || (user is { } u && u.Id == Id)) ? "true" : "Пользователь с таким имененем уже существует";
        return Json(result);
    }

    #endregion

    /// <summary> Вебмодель просмотра пользователя </summary>
    public class UserWebModel
    {
        public string Id { get; set; }

        [Display(Name = "Фамилия пользователя")]
        public string SurName { get; set; }

        [Display(Name = "Имя пользователя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество пользователя")]
        public string Patronymic { get; set; }

        [Display(Name = "Логин пользователя")]
        public string UserName { get; set; }

        [Display(Name = "Почта пользователя")]
        public string Email { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "Компания")]
        public string CompanyName { get; set; }

        [Display(Name = "Роли у этого пользователя")]
        public IEnumerable<string> RolesNames { get; set; } = Enumerable.Empty<string>();
    }

    /// <summary> Вебмодель редактирования пользователя </summary>
    public class UserEditWebModel
    {
        [HiddenInput(DisplayValue = false)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для пользователя")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Фамилия должна быть длинной от 3 до 200 символов")]
        [Display(Name = "Фамилия пользователя")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Имя обязательно для пользователя")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Имя должно быть длинной от 3 до 200 символов")]
        [Display(Name = "Имя пользователя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Отчество обязательно для пользователя")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Отчество должно быть длинной от 3 до 200 символов")]
        [Display(Name = "Отчество пользователя")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Нужно обязательно ввести свой адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Нужно ввести корректный адрес своей электронной почты")]
        [Display(Name = "Адрес электронной почты E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна для ввода")]
        [Display(Name = "День рождения пользователя")]
        public DateTime Birthday { get; set; } = DateTime.Today.AddYears(-18);

        public IEnumerable<Role> AllRoles { get; set; } = Enumerable.Empty<Role>();
        [Display(Name = "Назначенные роли для пользователя")]
        public IEnumerable<string> UserRoles { get; set; } = Enumerable.Empty<string>();


        [Required(ErrorMessage = "Нужно обязательно ввести логин пользователя")]
        [Display(Name = "Логин пользователя")]
        [Remote("IsNameFree", "User", AdditionalFields = "Id")]
        public string UserName { get; set; }

        [Display(Name = "Новый пароль пользователя")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

