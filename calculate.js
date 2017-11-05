var x = 0;
var y = 0;
var op = '+';

function fNum(but)
{
	form.resField.value += but.value; 
}

function fOper(but)
{
    if (but.value != '=')
    {
        x = form.resField.value;
        form.resField.value = "";
        op = but.value;
    }
    else
    {
        y = form.resField.value;
        form.resField.value = calculate(x, y, op);
    }
}

function calculate(a, b, op) 
{
	if(op == '+')
		op = '%2b';

	var req = "a="+a+"&b="+b+"&op="+op;
	var rr = new XMLHttpRequest();
	rr.open('GET', 'http://localhost:2345?'+req, false);
	rr.send(null);
	return rr.responseText;
}