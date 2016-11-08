// JavaScript Document
$(document).ready(function () {
	$('#courtOrder').hide();

	$('#courtOrder_No').click(function () {
		$('#courtOrder').hide();
	});
	$('#courtOrder_Yes').click(function () {
		$('#courtOrder').show();
	});

	$('#update').hide();

	$('#updatebtn').click(function () {
		$('#update').toggle();
	});

	$('#contactUpdate').hide();

	$('#contactUpdateBtn').click(function () {
		$('#contactUpdate').toggle();
	});

	$('#languageUpdate').hide();

	$('#languageUpdateBtn').click(function () {
		$('#languageUpdate').toggle();
	});

	$('#courtOrderUpdate').hide();

	$('#courtOrderUpdateBtn').click(function () {
		$('#courtOrderUpdate').toggle();
	});

	$('#contactInfo').hide();

	$('#contactbtn').click(function () {
		$('#contactInfo').toggle();
	});

	$('#language').hide();

	$('#languagebtn').click(function () {
		$('#language').toggle();
	});

	$('#courtOrder').hide();

	$('#courtOrderbtn').click(function () {
		$('#courtOrder').toggle();
	});

	$('#training').hide();

	$('#trainingbtn').click(function () {
		$('#training').toggle();
	});
});

