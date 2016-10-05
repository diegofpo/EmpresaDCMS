document.onmousedown = disableclick;
status = "Copyright © 2016 DCMS Help.";
function disableclick(event)
{
    if (event.button == 2)
    {
        alert(status);
        return false;
    }
}
