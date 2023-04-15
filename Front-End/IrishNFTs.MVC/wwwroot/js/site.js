// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Hide the edit form and save button initially
    $('.product-edit').hide();
    $('.cancel-edit').hide();
    $('.save-product-edit-btn').hide();

    // When the edit button is clicked
    $('.edit-product-btn').click(function () {
        // Show the edit form and save button, and hide the read-only input and edit button
        $('.product-read').hide();
        $('.cancel-edit-btn').show();
        $('.product-edit').show();
        $('.save-product-edit-btn').show();
        $('.edit-product-btn').hide();
    });

    $('.cancel-edit-btn').click(function () {
        // Show the edit form and save button, and hide the read-only input and edit button
        $('.product-read').show();
        $('.cancel-edit-btn').show();
        $('.product-edit').hide();
        $('.save-product-edit-btn').hide();
        $('.edit-product-btn').show();
    });

    // When the save button is clicked
    $('.save-product-edit-btn').click(function () {
        // Update the value of the read-only input with the new value from the edit form
        $('.product-read').val($('.product-edit').val());
        // Hide the edit form and save button, and show the read-only input and edit button
        $('.product-read').show();
        $('.product-edit').hide();
        $('.edit-product-btn').show();
        $('.save-product-edit-btn').hide();
    });
});