Hex
===

Extensions to HtmlHelper to provide a fluent strongly-type way of specified attributes. Every existing HtmlHelper method that exists has had overloads added to provide a strongly-typed fluent way of adding additional HTML attributes.

### Adding HTML Attributes
To use Hex, all you need to do is change the anonymous object to the lambda expression. For example, currently you add additional HTML attributes to a TextBox using the following:

    @Html.TextBox( "MyTextBox", "Value", new { autocomplete = "autocomplete", @class = "MyClass1 MyClass2" } )

With Hex, you can now specify it with the following:

    @Html.TextBox( "MyTextBox", "Value", x => x
        .AutoComplete()
        .AddClass( "MyClass1", "MyClass2" ) )

### Conditions
Hex also supports specifying additional HTML attributes based on a condition being true or false.

    @Html.TextBox( "MyTextBox", "Value", x => x
        .AutoComplete()
        .AddClass( "MyClass" )
        .If( condition,
            t => t
                .AddClass( "TrueClass" ),
            f => f
                .AddClass( "FalseClass" ) ) )

### NuGet
It is located up on NuGet at the following location:

https://nuget.org/packages/Hex/
