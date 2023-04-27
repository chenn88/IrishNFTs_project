



$(document).ready(function () {


    //LOGIC FOR EDITING PRODUCT ON PRODUCTS ADMIN PAGE

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

    //END OF LOGIC FOR EDITING PRODUCT ON PRODUCTS ADMIN PAGE

    // ANIMATION FOR IMAGE TILES ON LANDING PAGE 
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

    // END OF ANIMATION FOR IMAGE TILES ON LANDING PAGE 

    // CARD FORM VALIDATION FOR PAYMENT
    var cardNumberInput = $("#CardNum");
    cardNumberInput.keyup(function () {
        var val = this.value.replace(/\s/g, '');
        var newVal = '';
        for (var i = 0; i < val.length; i++) {
            if (i % 4 == 0 && i > 0) newVal = newVal.concat(' ');
            newVal = newVal.concat(val[i]);
        }
        this.value = newVal;
    });

    var expirationDateInput = $("#CardExp");

    expirationDateInput.keyup(function () {
        var val = this.value.replace(/\//g, '');
        var newVal = '';
        for (var i = 0; i < val.length; i++) {
            if (i == 2) newVal = newVal.concat('/');
            newVal = newVal.concat(val[i]);
        }
        this.value = newVal;
    });

    $("#submit-order").click(function (event) {
        event.preventDefault();

        // Get input values

        var cardNumber = $("#CardNum").val();
        var cardholderName = $("#PaymentCardName").val();
        var expirationDate = $("#CardExp").val();
        var cvcCode = $("#CardCvv").val();



        // Regular expressions for validation
        var cardNumberPattern = /^[\d ]{19}$/;
        var cardholderNamePattern = /^[a-zA-Z\s]+$/;
        var expirationDatePattern = /^(0[1-9]|1[0-2])\/([0-9]{2})$/;
        var cvcCodePattern = /^[0-9]{3}$/;

        // Validate input values against patterns
        var isValid = true;
        if (!cardNumberPattern.test(cardNumber)) {
            $("#CardNum").addClass("is-invalid");
            isValid = false;
        } else {
            $("#CardNum").removeClass("is-invalid");
        }
        if (!cardholderNamePattern.test(cardholderName)) {
            $("#PaymentCardName").addClass("is-invalid");
            isValid = false;
        } else {
            $("#PaymentCardName").removeClass("is-invalid");
        }
        if (!expirationDatePattern.test(expirationDate)) {
            $("#CardExp").addClass("is-invalid");
            isValid = false;
        } else {
            $("#CardExp").removeClass("is-invalid");
        }
        if (!cvcCodePattern.test(cvcCode)) {
            $("#CardCvv").addClass("is-invalid");
            isValid = false;
        } else {
            $("#CardCvv").removeClass("is-invalid");
        }

        if (!isValid) {
            // If validation fails, stop form submission and show an error message
            return false;
        }

        // If all validations pass, submit the form or process the payment
        $("form").submit();
    });

    //END OF FORM VALIDATION FOR PAYMENT

});



