$(document).ready(function() {
"use strict";

	$(function(){

		// if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
		// 	//from default landing
		// 	$( ".side-left" ).on( "swiperight", swipeleftHandler );
		// 	$( ".side-right" ).on( "swipeleft", swiperightHandler );
		//
		// 	// From left page
		// 	$( ".page-left" ).on( "swipeleft", swiperightFromLeftPageHandler );
		// 	// From from right page
		// 	$( ".page-right" ).on( "swiperight", swiperightFromRightPageHandler );
		//
		// }

		console.log($( "#mobileChecker" ).css('display'));
		if( $( "#mobileChecker" ).css('display') == 'block') {

			alert("foind")
			//from default landing
			$( ".side-left" ).on( "swiperight", swipeleftHandler );
			$( ".side-right" ).on( "swipeleft", swiperightHandler );

			// From left page
			$( ".page-left" ).on( "swipeleft", swiperightFromLeftPageHandler );
			// From from right pagee,
			$( ".page-right" ).on( "swiperight", swiperightFromRightPageHandler );

		}


		function swipeleftHandler( event ){
			$( "#splitlayout").removeClass( "close-right" );
			$( "#splitlayout").removeClass( "open-right" );
			$( "#splitlayout").removeClass( "reset-layout");
			$( "#splitlayout").addClass( "open-left" );
		}
		function swiperightHandler( event ){
			$( "#splitlayout").removeClass( "close-left" );
			$( "#splitlayout").removeClass( "open-left" );
			$( "#splitlayout").removeClass( "reset-layout" );
			$( "#splitlayout").addClass( "open-right" );
		}
		//end of default landing

		// From left page
		function swiperightFromLeftPageHandler(){
			$( "#splitlayout").addClass( "close-left " );
			$( "#splitlayout").removeClass( "open-left " );
			// $( "#splitlayout").addClass( "reset-layout" );
			setTimeout(function(){
				$( "#splitlayout").addClass( "reset-layout" );
			}, 600);
		}
		// From from right page
		function swiperightFromRightPageHandler(){
			$( "#splitlayout").addClass( "close-right " );
			$( "#splitlayout").removeClass( "open-right " );
			// $( "#splitlayout").addClass( "reset-layout" );
			setTimeout(function(){
				$( "#splitlayout").addClass( "reset-layout" );
			}, 600);
		}


	});
});