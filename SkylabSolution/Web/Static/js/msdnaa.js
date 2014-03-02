$(document).ready(function () {

    $.fn.max = function (selector) {
        return Math.max.apply(null, this.map(function (index, el) { return selector.apply(el); }).get());
    };

    $('.content-box')
    	.height(function () {
    	    var maxHeight = $(this).closest('.content-container').find('.content-box').max(function () {
    	        return $(this).height();
    	    });
    	    return maxHeight;
    	})
	    .hover(
	    	function () {
	    	    $(this).css('background-color', '#f3f3f3');
	    	},
	    	function () {
	    	    $(this).css('background-color', '#eee');
	    	}
	    );


    function decodeEmail(encodedEmail) {
        /// <summary>
        /// Decodes the encoded e-mail address given as parameter.
        /// </summary>
        /// <param name="encodedEmail" type="String">The encoded e-mail address.</param>

        var email = '';
        for (var i = 0; i < encodedEmail.length;) {
            var letter = '';
            letter = encodedEmail.charAt(i) + encodedEmail.charAt(i + 1);
            email += String.fromCharCode(parseInt(letter, 16));
            i += 2;
        }
        return email;
    };


    function sendEmail(encodedEmail, subject, body) {
        /// <summary>
        /// Opens the default e-mail client and initializes the e-mail, subject and body fields.
        /// </summary>
        /// <param name="encodedEmail" type="String">The encoded e-mail address.</param>
        /// <param name="subject" type="String" optional="true">The subject of the e-mail.</param>
        /// <param name="body" type="String" optional="true">The body text of the e-mail.</param>

        // Decode the encoded e-mail address.
        var email = decodeEmail(encodedEmail);

        // Build a "mailto" URL.
        var url = 'mailto:' + email;
        if (typeof subject != 'undefined' && subject.length > 0) {
            url += '?Subject=' + subject;
        }
        if (typeof body != 'undefined' && body.length > 0) {
            url += '&Body=' + body;
        }

        // Redirect the browser to the "mailto" URL.
        window.location.href = url;
    };


    var $emailLinks = $('.email-link');
    $emailLinks.each(function () {
        $(this)
            .html(decodeEmail($(this).data('text')))
            .click(function (e) {
                e.preventDefault();
                sendEmail($(this).data('code'), $(this).data('subject'), $(this).data('body'));
            });
    });

    if (window.location.href.indexOf('index.html') > 0 || window.location.href === 'http://msdnaa.bme.hu/')
        $('#mnuKezdolap').addClass('active');

    if (window.location.href.indexOf('letoltes.htm') > 0)
        $('#mnuLetoltes').addClass('active');

    if (window.location.href.indexOf('gyik.htm') > 0)
        $('#mnuGyik').addClass('active');

    if (window.location.href.indexOf('kapcsolatfelvetel.htm') > 0)
        $('#mnuKapcsolat').addClass('active');

});