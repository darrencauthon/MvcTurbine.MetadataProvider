MvcTurbine.MetadataProvider
===========
# What is it?
MvcTurbine.MetadataProvider is a small add-on to MvcTurbine that allows you to quickly build custom metadata attributes for your Asp.Net MVC application.

# How do you use it?

Add a reference to MvcTurbine.MetadataProvider.dll from your MvcTurbine application.  It will automatically load a custom, extendable metadata provider that will allow you to create your own metadata attributes and handlers.

And don't worry, the metadata provider inherits from the default MVC2 metadata provider so you'll still be able to use the out-of-the-box MVC2 metadata attributes.

# Example

Say you wanted to convert a 'State' field from an open text box to a dropdown list of states.  Let's also say you already had a display template named 'DropDownList' that will render a list of strings loaded in metadata. 

If your input model looked like this:

`
	public class AddressInputModel{
		public string State { get; set; }
	}
`

You could create a metadata attribute with a handler, like so:

`
	public class StateDropdownAttribute : MetadataAttribute{}

	public class StateDropdownAttributeHander : IMetadataAttributeHandler<StateDropdownAttribute>
	{
		public void AlterMetadata(ModelMetadata metadata, CreateMetadataArguments args)
		{
			metadata.TemplateHint = "DropDownList";
			metadata.AdditionalValues["Items"] = new[] {"Kansas", "Missouri"};
		}
	}
`

Then just decorate your input model with your new attribute, and your custom metadata handler will be run whenever MVC retrieves metadata for your object.
