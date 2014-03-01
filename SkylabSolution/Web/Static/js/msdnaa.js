$( document ).ready( function() {

	$.fn.max = function(selector) { 
	    return Math.max.apply(null, this.map(function(index, el) { return selector.apply(el); }).get() ); 
	}


    $('.content-box')
    	.height(function () {
	        var maxHeight = $(this).closest('.content-container').find('.content-box').max( function () {
	            return $(this).height();
	        });
	        return maxHeight;
	    })
	    .hover(
	    	function()
	    	{
	    		$(this).css( 'background-color', '#f3f3f3' ); 
	    	},
	    	function()
	    	{
	    		$(this).css( 'background-color', '#eee' );
	    	}
	    );
    
    
    if( window.location.href.indexOf( 'index.html' ) > 0 || window.location.href === 'http://msdnaa.bme.hu/' )
    	$( '#mnuKezdolap' ).addClass( 'active' ); 

    if( window.location.href.indexOf( 'letoltes.htm' ) > 0 )
    	$( '#mnuLetoltes' ).addClass( 'active' ); 

    if( window.location.href.indexOf( 'gyik.htm' ) > 0 )
    	$( '#mnuGyik' ).addClass( 'active' ); 

    if( window.location.href.indexOf( 'kapcsolatfelvetel.htm' ) > 0 )
    	$( '#mnuKapcsolat' ).addClass( 'active' ); 

});