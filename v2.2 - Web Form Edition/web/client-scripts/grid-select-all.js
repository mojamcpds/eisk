function SelectAll(frmId,id)
{

 var frm = document.getElementById(frmId);
   
   
    for (i=1;i<frm.rows.length;i++)
    {
   
        frm.rows[i].cells[6].childNodes[1].checked=document.getElementById(id).checked;
    
    }

}
function SelectAllChkBox(frmId,id,cellNo)
{
    var frm = document.getElementById(frmId);
    for (i=1;i<frm.rows.length;i++)
        frm.rows[i].cells[cellNo].childNodes[1].checked=document.getElementById(id).checked;
   
}

