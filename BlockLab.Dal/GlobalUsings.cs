// dotnet ef --startup-project ../BlockLab/ migrations add init --context BlockLabContext

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Configuration;
global using BlockLab.Domain;
global using BlockLab.Dal.Data;
global using BlockLab.Domain.Entites;