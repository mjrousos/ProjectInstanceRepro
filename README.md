# Overview

I've been running into errors when loading projects with MSBuild APIs in test projects.

# Repro steps

1. Run the ProjectInstanceRepro app and notice that it runs successfully.
1. Run `dotnet test` on either TestProj or mstest projects (I included both to convince myself this issue isn't test framework-specific). Notice the error.

The tests fail with error:

```cmd
  Error Message:
   Microsoft.Build.Exceptions.InvalidProjectFileException : The expression "[MSBuild]::GetTargetFrameworkIdentifier(net5.0)" cannot be evaluated. MSB0001: Internal MSBuild Error: A required NuGet assembly was not found. Expected Path: C:\Program Files\dotnet\sdk\6.0.100-preview.2.21155.3  C:\Program Files\dotnet\sdk\6.0.100-preview.2.21155.3\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.TargetFrameworkInference.targets
  Stack Trace:
     at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject[T1,T2](IElementLocation elementLocation, String resourceName, T1 arg0, T2 arg1)
   at Microsoft.Build.Evaluation.Expander`2.Function`1.Execute(Object objectInstance, IPropertyProvider`1 properties, ExpanderOptions options, IElementLocation elementLocation)
   at Microsoft.Build.Evaluation.Expander`2.PropertyExpander`1.ExpandPropertyBody(String propertyBody, Object propertyValue, IPropertyProvider`1 properties, ExpanderOptions options, IElementLocation elementLocation, UsedUninitializedProperties usedUninitializedProperties, IFileSystem fileSystem)
   at Microsoft.Build.Evaluation.Expander`2.PropertyExpander`1.ExpandPropertiesLeaveTypedAndEscaped(String expression, IPropertyProvider`1 properties, ExpanderOptions options, IElementLocation elementLocation, UsedUninitializedProperties usedUninitializedProperties, IFileSystem fileSystem)
   at Microsoft.Build.Evaluation.Expander`2.PropertyExpander`1.ExpandPropertiesLeaveEscaped(String expression, IPropertyProvider`1 properties, ExpanderOptions options, IElementLocation elementLocation, UsedUninitializedProperties usedUninitializedProperties, IFileSystem fileSystem)
   at Microsoft.Build.Evaluation.Expander`2.ExpandIntoStringLeaveEscaped(String expression, ExpanderOptions options, IElementLocation elementLocation)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluatePropertyElement(ProjectPropertyElement propertyElement)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluatePropertyGroupElement(ProjectPropertyGroupElement propertyGroupElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Execution.ProjectInstance.Initialize(ProjectRootElement xml, IDictionary`2 globalProperties, String explicitToolsVersion, String explicitSubToolsetVersion, Int32 visualStudioVersionFromSolution, BuildParameters buildParameters, ILoggingService loggingService, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, Nullable`1 projectLoadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Execution.ProjectInstance..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, Nullable`1 projectLoadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Execution.ProjectInstance..ctor(String projectFile)
   at ProjectInstanceRepro.Program.LoadTestProject() in D:\scratch\ProjectInstanceRepro\ProjectInstanceRepro\Program.cs:line 22
   at ProjectInstanceRepro.Program.Main() in D:\scratch\ProjectInstanceRepro\ProjectInstanceRepro\Program.cs:line 17
   at TestProj.UnitTest1.Test1() in D:\scratch\ProjectInstanceRepro\TestProj\UnitTest1.cs:line 12
```