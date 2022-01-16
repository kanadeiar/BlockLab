namespace BlockLab.Dal.TestData;

/// <summary> Заполнение базы данных тестовыми данными </summary>
public static class BlockLabSeedTestData
{
    private static Random rnd = new Random();
    /// <summary> Заполнение базы данных тестовыми данными </summary>
    /// <param name="serviceProvider">Провайдер</param>
    /// <param name="configuration">Корфигурация</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static async void SeedTestData(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        serviceProvider = serviceProvider.CreateScope().ServiceProvider;
        using (var context = new BlockLabContext(serviceProvider.GetRequiredService<DbContextOptions<BlockLabContext>>()))
        {
            var logger = serviceProvider.GetRequiredService<ILogger<BlockLabContext>>();
            if (context == null || context.Researches == null)
            {
                logger.LogError("Null BlockLabContext");
                throw new ArgumentNullException("Null BlockLabContext");
            }
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                logger.LogInformation($"Applying migrations: {string.Join(",", pendingMigrations)}");
                await context.Database.MigrateAsync();
            }
            if (context.Researches.Any())
            {
                logger.LogInformation("Database contains data - database init with test data is not required");
                return;
            }

            logger.LogInformation("Begin writing test data to database BlockLabContext ...");

            var la1 = new LabAssistant
            {
                SurName = "Петрова",
                FirstName = "Юлия",
                Patronymmic = "Петровная",
                Birthday = DateTime.Today.AddYears(-20),
            };
            var la2 = new LabAssistant
            {
                SurName = "Иванова",
                FirstName = "Наталья",
                Patronymmic = "Ивановна",
                Birthday = DateTime.Today.AddYears(-25),
            };
            var la3 = new LabAssistant
            {
                SurName = "Сидорова",
                FirstName = "Елена",
                Patronymmic = "Сидоровна",
                Birthday = DateTime.Today.AddYears(-30),
            };
            var la4 = new LabAssistant
            {
                SurName = "Медведева",
                FirstName = "Соня",
                Patronymmic = "Медведевна",
                Birthday = DateTime.Today.AddYears(-18),
            };
            context.LabAssistants.AddRange(la1, la2, la3);
            await context.SaveChangesAsync();

            var ro1 = new ResearchObject { Name = "Сырой газобетонный массив", };
            var ro2 = new ResearchObject { Name = "Созревший газобетонный массив", };
            var ro3 = new ResearchObject { Name = "Разрезанный газобетонный массив", };
            var ro4 = new ResearchObject { Name = "Твердый газобетонный массив после автоклавов", };
            var ro5 = new ResearchObject { Name = "Газобетонный блок после сортировки", };
            var ro6 = new ResearchObject { Name = "Цемент" };
            var ro7 = new ResearchObject { Name = "Молото-вяжущее" };
            var ro8 = new ResearchObject { Name = "Шлам" };
            context.ResearchObjects.AddRange(ro1, ro2, ro3, ro4, ro5, ro6, ro7, ro8);
            await context.SaveChangesAsync();

            var tr1 = new TypeResearch { Name = Names.VeguenessName, TypeResult = TypeResearch.ItTypeResult.Simple };
            var tr2 = new TypeResearch { Name = Names.VisualName, TypeResult = TypeResearch.ItTypeResult.Simple };
            var tr3 = new TypeResearch { Name = Names.BlockQualityName, TypeResult = TypeResearch.ItTypeResult.BlockQualityResearch };
            var tr4 = new TypeResearch { Name = Names.CementName, TypeResult = TypeResearch.ItTypeResult.CementReseatch };
            var tr5 = new TypeResearch { Name = Names.HammerBinderName, TypeResult = TypeResearch.ItTypeResult.HammerBinderResearch };
            var tr6 = new TypeResearch { Name = Names.MudName, TypeResult = TypeResearch.ItTypeResult.MudResearch };
            context.TypeResearches.AddRange(tr1, tr2, tr3, tr4, tr5, tr6);
            await context.SaveChangesAsync();

            var wsA = new WorkShift { Name = "Смена А" };
            var wsB = new WorkShift { Name = "Смена Б" };
            var wsC = new WorkShift { Name = "Смена В" };
            var wsD = new WorkShift { Name = "Смена Г" };
            context.WorkShifts.AddRange(wsA, wsB, wsC, wsD);
            await context.SaveChangesAsync();

            var assistants = await context.LabAssistants.ToDictionaryAsync(i => i.Id, i => i);
            var workshifts = await context.WorkShifts.ToDictionaryAsync(i => i.Id, i => i);
            context.Researches.AddRange(Enumerable.Range(1, 20).Select(i => new Research
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат исследования № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Результат удовлетворителен",
                IsNormal = true,
                TypeResearch = tr1,
                ResearchObject = ro1,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
            }));
            context.Researches.AddRange(Enumerable.Range(1, 10).Select(i => new Research
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат исследования № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Результат плохой",
                IsNormal = false,
                Note = "Заметка о плохом результате",
                TypeResearch = tr1,
                ResearchObject = ro1,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
            }));
            context.Researches.AddRange(Enumerable.Range(1, 5).Select(i => new Research
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат внешнего осмотра № {rnd.Next(100)}",
                Text = "Линзы, Сколы от подрезного слоя, Следы от решеток.",
                IsNormal = true,
                TypeResearch = tr2,
                ResearchObject = ro5,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
            }));
            await context.SaveChangesAsync();
            context.BlockQualityResearches.AddRange(Enumerable.Range(1, 10).Select(i => new BlockQualityResearch
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат по качеству блоков № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Удовлетворительно.",
                IsNormal = true,
                TypeResearch = tr3,
                ResearchObject = ro4,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
                Format = "100x200x500",
                Trademark = "D500",
                Weight = rnd.NextDouble() * 30.0 + 600.0,
                SizeX = 10.0,
                SizeY = 10.0,
                SizeZ = 10.0,
                RawDensity = rnd.NextDouble() * 70.0 + 600.0,
                Coefficient = 1.15,
                RawWeight = 650.0,
                DriedWeight = 500.0,
                Humidity = 30.0,
                Load = 32.91,
                Strength = 3.53,
                DriedDensity = 511.0,
            }));
            await context.SaveChangesAsync();
            context.CementResearches.AddRange(Enumerable.Range(1, 10).Select(i => new CementResearch
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат по цементу № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Удовлетворительно.",
                IsNormal = true,
                TypeResearch = tr4,
                ResearchObject = ro6,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
                Party = rnd.Next(10, 100).ToString(),
                PassportVc = rnd.NextDouble() + 30.0,
                PassportNsh = rnd.NextDouble() + 180.0,
                PassportKsh = rnd.NextDouble() + 250.0,
                ActualVc = rnd.NextDouble() + 30.0,
                ActualNsh = rnd.NextDouble() + 180.0,
                ActualKsh = rnd.NextDouble() + 250.0,
                FromName = $"г.Вольск ЦЕМ 1 {(rnd.NextDouble() * 50.0):F1} Н",
            }));
            await context.SaveChangesAsync();
            context.HammerBinderResearches.AddRange(Enumerable.Range(1, 10).Select(i => new HammerBinderResearch
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат по молото-вяжущему № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Удовлетворительно.",
                IsNormal = true,
                TypeResearch = tr5,
                ResearchObject = ro7,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
                Sieve0_2 = rnd.Next(1000),
                Surface = 2.75,
                Perfomance = 5.2,
                Activity = rnd.NextDouble() * 20.0 + 50.0,
            }));
            await context.SaveChangesAsync();
            context.MudResearches.AddRange(Enumerable.Range(1, 10).Select(i => new MudResearch
            {
                DateTime = DateTime.Today.AddDays(- rnd.Next(12)).AddHours(rnd.Next(14)).AddMinutes(rnd.Next(59)),
                Name = $"Результат по шламу № {rnd.Next(100)}",
                Value = rnd.NextDouble() * 100.0,
                Text = "Удовлетворительно.",
                IsNormal = true,
                TypeResearch = tr6,
                ResearchObject = ro8,
                LabAssistant = assistants[rnd.Next(assistants.Count) + 1],
                WorkShift = workshifts[rnd.Next(workshifts.Count) + 1],
                Density = rnd.Next(1500, 1600),
                Surface = rnd.Next(2500, 3000),
                Sieve0_8 = rnd.NextDouble() + 30.0,
                Sieve0_09 = rnd.NextDouble() + 30.0,
                Sieve0_045 = rnd.NextDouble() + 30.0,
                Humidity = rnd.NextDouble() + 30.0,
            }));
            await context.SaveChangesAsync();

            logger.LogInformation("Complete writing test data to database BlockLabContext ...");
        }
    }
}

