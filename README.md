AssemblyDiscovery
=================

CI Environment: https://ci.appveyor.com/project/patrinhani-ciandt/assemblydiscovery

NuGet Feed: https://www.myget.org/F/bohriumnet/

Usage Example:

XML Validation Input Example:
<pre><code>
<?xml version="1.0" encoding="utf-8"?>
<AssemblyValidator xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ValidatorDefinitions>
    <References>
      <ValidatorDefinitionReference AssemblyName="mscorlib" Version="4.0.0.0" Allowed="true" ErrorType="Error" />
      <ValidatorDefinitionReference AssemblyName="SampleProject.ClassLib01" Version="1.0.0.0" Allowed="true" ErrorType="Error" />
    </References>
  </ValidatorDefinitions>
</AssemblyValidator>
</code></pre>
