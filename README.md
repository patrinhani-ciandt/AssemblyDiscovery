AssemblyDiscovery
=================

CI Environment: https://ci.appveyor.com/project/patrinhani-ciandt/assemblydiscovery

NuGet Feed: https://www.myget.org/F/bohriumnet/

Usage Example:

XML Validation Input Example:
SampleProject.ConsoleApp-val.xml
<pre><code>
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;AssemblyValidator xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;
  &lt;ValidatorDefinitions&gt;
    &lt;References&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;mscorlib&quot; Version=&quot;4.0.0.0&quot; Allowed=&quot;true&quot; ErrorType=&quot;Error&quot; /&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;SampleProject.ClassLib01&quot; Version=&quot;1.0.0.0&quot; Allowed=&quot;true&quot; ErrorType=&quot;Error&quot; /&gt;
    &lt;/References&gt;
  &lt;/ValidatorDefinitions&gt;
&lt;/AssemblyValidator&gt;
</code></pre>
