function AddToCart(productid, unitsinstock) {
    var addedAmount = $("#quantityInput1").val();

    if (addedAmount <= unitsinstock && addedAmount != 0) {
        $.ajax({
            type: "POST",
            url: "/cart/addtocart",
            data: { "productid": productid, "quantity": addedAmount },
            success: function (productname) {
                if (addedAmount != null) {
                    addedAmount == 1 ? alert(addedAmount + " " + productname + " has been successfully added to your cart.") : addedAmount > 1 ? alert(addedAmount + " " + productname + " have been successfully added to your cart.") : "?";

                    GetItemCount();
                }
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }
    else {
        if (addedAmount == 0) {
            alert("You must add a minimum of 1 item.");
        }
        else {
            alert("There aren't enough items in stock. You can add a maximum of " + unitsinstock + " items.");
        }
    }
}

function GetItemCount() {
    $.ajax({
        type: "GET",
        url: "/cart/itemcount",
        success: function (itemcount) {
            $(".shopping-card span").text(itemcount)
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

$(".cart-table .qtybtn").on("click", function () {
    var row = $(this).closest("tr");

    if ($(this).hasClass("inc")) {
        if (row.find(".pro-qty input").val() != parseInt(row.find(".stock-col h5").text())) {
            var isIncreased = true;

            UpdatePrice(isIncreased, row);
        }
        else {
            var tempNumber = row.find(".pro-qty input").val();
            row.find(".pro-qty input").val(tempNumber - 1);

            alert("The quantity of the product cannot exceed the product's stock level.")
        }
    }
    else {
        if (row.find(".pro-qty input").val() != 0) {
            var isIncreased = false;

            UpdatePrice(isIncreased, row);
        }
        else {
            alert("The quantity of the product cannot be less than 0.\nPlease enter a valid quantity.");
        }
    }
});

function UpdatePrice(isIncreased, row) {   
    var productid = row.data("product-id");
    var totalPrice = parseFloat(row.find(".total-col h4").text().replace("$", ""));
    var grandTotalPrice = parseFloat($(".total-cost span").text().replace("$", ""));

    $.ajax({
        type: "POST",
        url: "/cart/updateprice",
        data: { "productid": productid, "isIncreased": isIncreased },
        success: function (priceChange) {
            totalPrice += priceChange;
            grandTotalPrice += priceChange;

            row.find(".total-col h4").text("$" + totalPrice.toFixed(2));
            $(".total-cost span").text("$" + grandTotalPrice.toFixed(2));

            UpdateCartCount(isIncreased);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function UpdateCartCount(isIncreased) {
    if (isIncreased) {
        var shoppingCartAmount = parseInt($(".shopping-card span").text());
        shoppingCartAmount++;
        $(".shopping-card span").text(shoppingCartAmount);
    }
    else {
        var shoppingCartAmount = parseInt($(".shopping-card span").text());
        shoppingCartAmount--;
        $(".shopping-card span").text(shoppingCartAmount);
    }
}

function SelectPaymentOption(OptionInput) {
    var selectedOption = $(OptionInput).val();

    if (selectedOption != "") {

        $(".PaymentOption").slideUp();

        if (selectedOption == 1) {
            $(".creditCard").slideDown();
        }
        else if (selectedOption == 2) {
            $(".transfer").slideDown();
        }
        else {
            $(".COD").slideDown();
        }
    }
    else {
        $(".PaymentOption").slideUp();
    }
}

$(".checkout-form").submit(function (event) {
    event.preventDefault();

    var allInputsFilled = true;
    var message = "";

    $("#userinformationinputs input").each(function () {
        if ($(this).val().trim() == "") {
            allInputsFilled = false;
            return false;
        }
    });

    if (!allInputsFilled) {
        message = "You must fill in all the fields for user information.";
    }
    else if (!$("#ship-1").prop("checked") && !$("#ship-2").prop("checked")) {
        message = "You must choose a delivery option.";
    }
    else if ($(".selectPaymentOption").val() == "") {
        message = "You must choose a payment option.";
    }
    else if ($(".selectPaymentOption").val() == 1) {

        var isCardFilled = true;

        $(".PaymentOption.creditCard input").each(function () {
            if ($(this).val().trim() == "") {
                message = "You must fill in all the fields for card information.";
                isCardFilled = false;
                return false;
            }
        });

        if (isCardFilled) {
            if ($("#Order_CardExpirationM").val() == "" || $("#Order_CardExpirationY").val() == "") {
                message = "You must choose expiration date for card information.";
            }
        }
    }

    if (message == "") {
        event.currentTarget.submit();
    }
    else {
        alert(message);
    } 
});

$(".cf-radio-btns .cfr-item input").change(function () {
    var finalTotal2Price = parseFloat($("#finalTotal2 span").text().replace("$", ""));
    var shippingFee = parseFloat($("#shippingFeeLabel").text().replace("$", ""));

    if ($("#ship-2").prop("checked")) {
        finalTotal2Price += shippingFee;
        $("#finalShippingFee2 span").text("$" + shippingFee);
    }
    else {
        if ($("#finalShippingFee2 span").text() != "Free") {
            finalTotal2Price -= shippingFee;
            $("#finalShippingFee2 span").text("Free");
        }
    }

    $("#finalTotal2 span").text("$" + finalTotal2Price.toFixed(2));
});

// document.ready() Functions \\

$(document).ready(function () {

    GetItemCount();

    $(".fa-heart").click(function () {
        $(this).toggleClass("fa-regular fa-heart fa-solid fa-heart");
    });

    $(".fa-star").click(function () {
        var clickedRating = $(this).data("rating");

        $(".fa-solid.fa-star").toggleClass("fa-solid fa-star fa-regular fa-star");
        
        $(this).prevAll().addBack().toggleClass("fa-regular fa-star fa-solid fa-star");
    });
});