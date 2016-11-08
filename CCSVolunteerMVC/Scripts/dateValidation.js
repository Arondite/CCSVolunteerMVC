// JavaScript Document
// Date format validation
$(document).ready(function () {

	$('.error_date').hide();

	$('#btnSubmit').click(function (event) {
		var dtVal = $('#Date').val();
		if (ValidateDate(dtVal)) {
			$('.error_date').hide();
		}
		else {
			$('.error_date').show();
			event.preventDefault();
		}
	});
});

function ValidateDate(dtValue) {
	var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
	return dtRegex.test(dtValue);
}