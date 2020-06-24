var contact = (function () {

    function submitForm(form) {
        $('input[name="AJ"]', form).val('1');
        
        $.ajax({
            url: $(form).prop("action"),
            data: $(form).serialize(),
            success: function (s) {
                if (s.success) showThanks();
                form.reset();
            },
            error: function (err) {
                showError();
            },
            method: "post"
        });
    }

    function validate(form) {
        // Check privacy policy is ticked
        if (!$('.privacy-wrapper input[type="checkbox"]', form).prop("checked")) {
            $('.privacy-wrapper', form).addClass('error');
            return false;
        }

        $('.privacy-wrapper', form).removeClass('error');
        return true;
    }

    function showThanks() {
        $('.form-submitted').show();
        $('form').hide();

        window.setTimeout(function () {
            $('form').fadeIn(1000);
            $('.form-submitted').fadeOut(800);
        }, 5000);
    }

    function showError() {

    }

    return {
        Init: function () {
            $('.form-submitted').hide();

            $('form.contact-form').on('submit', function (ev) { ev.preventDefault(); if (validate(this)) submitForm(this); });

            $('.close-enquiry-form').on('click', function () {
                $('form').each(function () { this.reset() });
                $('.form-submitted').hide();
                $('form').show();
            });

            $('.privacy-wrapper input[type="checkbox"]').on('change', function (input) {
                if ($(this).prop("checked"))
                    $(this).parents('.privacy-wrapper').removeClass('error');
                else
                    $(this).parents('.privacy-wrapper').addClass('error');
            });
        }
    }
})();


$(function () {
   contact.Init();
});