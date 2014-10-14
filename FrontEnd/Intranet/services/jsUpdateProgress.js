Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
//Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler)
//Sys.WebForms.PageRequestManager.getInstance().remove_beginRequest(beginRequestHandler)


function beginReq(sender, args) {
	// shows the Popup 
	$find(ModalProgress).show();
}

function endReq(sender, args) {
	//  shows the Popup 
	$find(ModalProgress).hide();
} 
