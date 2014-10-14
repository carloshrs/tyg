// JScript File
function keyDown(e)
{
  if(document.all) 
  {
      tecla = window.event.keyCode;
      obj = window.event.srcElement;
  }
  else
  {
      tecla = e.which; 
      obj = e.target;
  }
  if(tecla!=13 || obj.type == 'textarea') return;
  frm=obj.form; 
  if( frm == null )
  {
    frm = document.forms[0];
    for(j=0;j<frm.elements.length;j++)
    {
        if( frm.elements[j].type != 'hidden' && frm.elements[j].type != 'image' && !frm.elements[j].disabled)
        {
            try
            {
                frm.elements[j].focus(); 
                break;
            }catch(e){}
        }
    }
    return false;
  }
  for(i=0;i<frm.elements.length;i++) 
    if(frm.elements[i]==obj) 
    { 
      for(j=i+1;j<frm.elements.length;j++)
      {
        if (j==frm.elements.length-1) j=-1; 
        else
        {
            if( frm.elements[j].type != 'hidden' && frm.elements[j].type != 'image' && !frm.elements[j].disabled )
            {
                try
                {
                    frm.elements[j].focus(); 
                    break;
                }catch(e){}
            }
        }
      }
      break;
    } 
    return false;
}
document.onkeydown = keyDown;