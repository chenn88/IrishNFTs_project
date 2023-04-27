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



    // Array of image sources
    var imageSources = [
        "/images/antique-spoons.jpg",
        "/images/art-mask.jpg",
        "/images/happy-clown.jpg",
        "/images/lady-after-picasso.jpg",
        "/images/maiya.jpg",
        "/images/marbles-on-blue-plate.jpg",
        "/images/metal-mask.jpg",
        "/images/mystique.jpg",
        "/images/new-york.jpg",
        "/images/orchid.jpg",
        "/images/resonator-deconstructed.jpg",
        "/images/spanish-doorway.jpg",
        "/images/summer-cocktails.jpg",
        "/images/the-aerialist.jpg",
        "/images/woman-with-a-fan.jpg",
        "/images/yellow-buttons.jpg",
        "/images/art-marbles-in-jar.jpg",
        "/images/doggie-daydreaming.jpg",
        "/images/lockdown-series-2.jpg",
        "/images/rose.jpg",
        "/images/woman-reading-after-picasso.jpg",
        "/images/charlie.jpg",
        "/images/face-of-climate-change.jpg",
        "/images/comedy-tragedy.jpg",
        "/images/pigeon-house-sunset.jpg",
        "/images/white-rose.jpg",
        "/images/masquerade.jpg",
        "/images/holiday-cocktails.jpg"
    ];


    function shuffle(array) {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]];
        }
    }

    function getRandomInt(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function changeImgSource(element) {
        shuffle(imageSources);
        var newImageIndex = getRandomInt(0, imageSources.length - 1);
        $(element).fadeOut(3000, function () {
            $(element).attr('src', imageSources[newImageIndex]);
            $(element).fadeIn(3000);
        });
    }

    function randomImageChange(element) {
        var randomInterval = getRandomInt(6000, 10000); // Random interval between 3s and 10s
        setTimeout(function () {
            changeImgSource(element);
            randomImageChange(element);
        }, randomInterval);
    }

    // Change image sources initially
    $('.landing-page-tile').each(function () {
        changeImgSource(this);
    });

    // Change image sources with random intervals
    $('.landing-page-tile').each(function () {
        randomImageChange(this);
    });

});



