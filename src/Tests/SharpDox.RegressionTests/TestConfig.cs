﻿using Moq;
using SharpDox.Build;
using SharpDox.Build.Context.Step;
using SharpDox.Build.Roslyn;
using SharpDox.Model;
using SharpDox.Sdk.Config;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace SharpDox.RegressionTests
{
    public static class TestConfig
    {
        public static SDProject ParseProject()
        {
            var testProjectPath =
                Path.Combine(
                Path.GetDirectoryName(Assembly.GetAssembly(typeof(Regression1)).Location),
                "..", "..", "..", "SharpDox.TestProject", "SharpDox.TestProject.csproj");
            
            var coreConfig = Mock.Of<ICoreConfigSection>(
                c => c.InputFile == testProjectPath &&
                c.ProjectName == "TestProject" &&
                c.DocLanguage == "en" &&
                c.ExcludedIdentifiers == new ObservableCollection<string>());
            
            var configController = Mock.Of<IConfigController>(
                c=> c.GetConfigSection<ICoreConfigSection>() == coreConfig);

            var stepInput = new StepInput(configController, new RoslynParser(Mock.Of<ParserStrings>()), new SDBuildStrings(), null);

            var config = new List<StepBase>();
            var checkConfig = new CheckConfigStep(stepInput, 0, 15);

            config.Add(new ParseProjectStep(stepInput, 0, 50));
            config.Add(new ParseCodeStep(stepInput, 50, 100));

            var sdProject = new SDProject();
            foreach (var step in config)
            {
                sdProject = step.RunStep(sdProject);
            }

            return sdProject;
        }
    }
}
