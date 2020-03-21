$(document).ready(function() {
"use strict";



	function getFiles(){
		// var directory="http://wordpress2.com/uploads/serviceicons";
		var directory="../uploads/serviceicons";
		var xmlHttp = new XMLHttpRequest();
		xmlHttp.open( "GET", directory, false ); // false for synchronous request
		xmlHttp.send( null );
		var ret=xmlHttp.responseText;

		var fileList=ret.split('\n');

		let str = "";
		let fileNames = [];
		// "href=\"service-qrbruce.png\">service-qrbruce.png</a></td><td"

		for(let i=0;i<fileList.length;i++){
			var fileinfo = fileList[i].split(' ');
			if ( i > 6 && i !== 20) {
				str += fileList[i];
				if(fileinfo.length > 4){
					if(fileinfo[4].indexOf('.png')  > -1){
						let subs = fileinfo[4];
						subs = fileinfo[4].substr(fileinfo[4].indexOf('"')+1);
						subs = subs.substr(0,subs.indexOf('"'));
						fileNames.push(subs);
					}
				}

			}
		}
		return fileNames;
	}

	// let files = getFiles();
	//
	//
	//
	// if(files.length > 0){
	//
	// 	let html = "";
	// 	for(let i=0; i < files.length;i++) {
	// 		html += '<div class="col-md-3 icon-gallery-item" style="background: url(uploads/serviceicons/'+ files[i] +') no-repeat center center;height: 121px"></div>'
	// 	}
	// 	$("#icon-gallery").html(html);
	// }




});