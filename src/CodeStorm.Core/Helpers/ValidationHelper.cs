using CodeStorm.Core.Checkers;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Constants;
using CodeStorm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStorm.Core.Helpers
{
    internal class ValidationHelper
    {
        public static bool IsValid(CheckerInput checkerInput)
        {
            ICheckerFactory checkerFactory = new CheckerFactory();
            if (!File.Exists(checkerInput.SourceCodePath)) throw new Exception("Source code file not found");
            if (!Directory.Exists(checkerInput.ProblemSetPath)) throw new Exception("ProblemSet directory not found");
            if (!Directory.Exists(checkerInput.MissionPath)) throw new Exception("Mission directory not found");
            if (!checkerFactory.IsSupportableLanguage(checkerInput.Language)) throw new Exception("This language is not supported");

            int codeSize = File.ReadAllText(checkerInput.SourceCodePath).Length;
            if (checkerInput.TimeLimit > EngineConstants.ENGINE_MAX_WAIT_TIME)
                throw new Exception($"Time limit should not exceed {EngineConstants.ENGINE_MAX_WAIT_TIME} ms");
            else if (checkerInput.MemoryLimit > EngineConstants.ENGINE_MAX_USAGE_MEMORY)
                throw new Exception($"Memory Limit should not exceed {EngineConstants.ENGINE_MAX_USAGE_MEMORY} KB");
            else if (codeSize > EngineConstants.MAXIMUM_CODE_SIZE)
                throw new Exception($"Code size should not exceed {EngineConstants.MAXIMUM_CODE_SIZE} characters");
            else return true;
        }
    }
}
