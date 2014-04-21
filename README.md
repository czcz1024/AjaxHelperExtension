AjaxHelperExtension
===================

asp.net mvc ajax helper extension
```
@using (Ajax.BeginForm(new AjaxOptions {
    OnBegin="$('#str').val('2')"
}))
{
    <input name="str" id="str" />
    <input type="submit" />
}
```
when change form value in OnBegin,ajax post still use the old value;
this js fix it;


```
@Ajax.RenderAction("AjaxLoad", "Test", new {id=1 }, new AjaxOptions { }, new {@class="test" })
```

add a extension method to auto load ajax content 
this will generate a div
and in js,send a ajax request
