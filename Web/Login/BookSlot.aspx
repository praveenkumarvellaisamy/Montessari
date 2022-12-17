<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookSlot.aspx.cs" Inherits="Montessari.Login.BookSlot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sparkles</title>
    <link href="../css/Googleapis1.css" rel="stylesheet" />
    <link href="../css/fontawesome.css" rel="stylesheet" />
    <link href="../css/Googleapis2.css" rel="stylesheet" />
    <link href="../css/Googleapis3.css" rel="stylesheet" />
    <link href="../css/MaterialIcon.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/popper.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/preloader.js"></script>
    <script src="../js/jquery.touchSlider.js"></script>
</head>
<body>
    <div id="preloader"></div>
    <!--------------------------------------------- Navbar ---------------------------------------->
    <nav class="navbar navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header"><a class="navbar-brand logo" href="#">
                <img src="../images/innerlogo.png" style="margin-top: 5px;" /></a> </div>
            <ul class="header-list">
                <li><a href="../Login/Profile.aspx">Home</a></li>
                <li><a href="#">Helpline</a></li>
                <li><a href="#">FAQs</a></li>
                <li><a href="#" data-toggle="modal" data-target="#packages">Packages</a></li>
                <li style="float: left">
                    <div class="cart">
                        <div class="fill"></div>
                    </div>
                </li>
                <li class="admin-name">
                    <img src="../images/user-img.png" />
                </li>
            </ul>
        </div>
    </nav>

    <!----------------------------------------------------- End Navbar ------------------------------------------------>
    <div class="container mt-5">
        <div class="row">
            <div class="col-lg-9">
                <div class="admin-wrap p-5">
                    <div class="row">
                        <div class="col-12">
                            <div class="float-left download-title pb-4">Choose your plan</div>
                            <span class="float-right timer">03:00</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3 pb-2 pt-2 booking-text bodr-bot">Select Child</div>
                        <div class="col-9 pb-2 pt-2 bodr-bot">
                            <select class="select-drop">
                                <option>---Select---</option>
                                <option>Jenifer R</option>
                            </select>
                        </div>
                        <div class="col-3 pb-2 pt-2 booking-text bodr-bot">Choose Plan</div>
                        <div class="col-9 pb-2 pt-2 bodr-bot">
                            <form name="colorSelectorForm">
                                <input type="radio" name="colorSelector" id="radio-pink" value="pink" />
                                <label for="radio-pink"><i class="material-icons">radio_button_checked</i>Fixed</label>
                                <input type="radio" name="colorSelector" id="radio-indigo" value="indigo" />
                                <label for="radio-indigo"><i class="material-icons">radio_button_checked</i>Flexible</label>
                                <input type="radio" name="colorSelector" id="radio-cyan" value="cyan" />
                                <label for="radio-cyan"><i class="material-icons">radio_button_checked</i>Corporate</label>
                            </form>
                        </div>
                        <div class="col-3 pb-2 pt-2 booking-text bodr-bot">Start Date</div>
                        <div class="col-9 pb-2 pt-2 bodr-bot">
                            <input type="text" class="form-control cal" name="date" id="stdate" data-select="datepicker">
                        </div>
                        <div class="col-3 pb-2 pt-2 booking-text">
                            End Date<br>
                            <div class="smtext">(Tentatively calculated)</div>
                        </div>
                        <div class="col-9 pb-2 pt-2 ">
                            <input type="text" class="form-control" name="date">
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-12">
                            <div class="float-left download-title mb-4">Book your slot</div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="time-picker-container">
                                <div class="time-picker">
                                    <div class="row time-picker-header">
                                        <button href="#" class="arrow left inactive"></button>
                                        <ul class="date-slot">
                                            <li class="date-slot-wrapper">
                                                <div class="date-slot-item"><span class="date-slot-day">July 6</span> <span class="date-slot-date">Mon</span> </div>
                                            </li>
                                            <li class="date-slot-wrapper">
                                                <div class="date-slot-item"><span class="date-slot-day">July 7</span> <span class="date-slot-date">Tue</span> </div>
                                            </li>
                                            <li class="date-slot-wrapper">
                                                <div class="date-slot-item"><span class="date-slot-day">July 8</span> <span class="date-slot-date">Wed</span> </div>
                                            </li>
                                            <li class="date-slot-wrapper">
                                                <div class="date-slot-item"><span class="date-slot-day">July 9</span> <span class="date-slot-date">Thu</span> </div>
                                            </li>
                                            <li class="date-slot-wrapper">
                                                <div class="date-slot-item"><span class="date-slot-day">July 10</span> <span class="date-slot-date">Fri</span> </div>
                                            </li>
                                        </ul>
                                        <button href="#" class="arrow right"></button>
                                    </div>
                                    <div class="row">
                                        <ul class="time-slot">
                                            <li class="time-slot-item deactive-days">10:00 AM</li>
                                            <li class="time-slot-item deactive-days">12:00 AM</li>
                                            <li class="time-slot-item">02:00 PM</li>
                                            <li class="time-slot-item">04:00 PM</li>
                                        </ul>
                                        <ul class="time-slot">
                                            <li class="time-slot-item">10:00 AM</li>
                                            <li class="time-slot-item">12:00 AM</li>
                                            <li class="time-slot-item">02:00 PM</li>
                                            <li class="time-slot-item">04:00 PM</li>
                                        </ul>
                                        <ul class="time-slot">
                                            <li class="time-slot-item">10:00 AM</li>
                                            <li class="time-slot-item">12:00 AM</li>
                                            <li class="time-slot-item">02:00 PM</li>
                                            <li class="time-slot-item">04:00 PM</li>
                                        </ul>
                                        <ul class="time-slot">
                                            <li class="time-slot-item">10:00 AM</li>
                                            <li class="time-slot-item">12:00 AM</li>
                                            <li class="time-slot-item">02:00 PM</li>
                                            <li class="time-slot-item">04:00 PM</li>
                                        </ul>
                                        <ul class="time-slot">
                                            <li class="time-slot-item">10:00 AM</li>
                                            <li class="time-slot-item">12:00 AM</li>
                                            <li class="time-slot-item">02:00 PM</li>
                                            <li class="time-slot-item">04:00 PM</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-12">
                            <div class="float-left download-title mb-4">Your Contact Details</div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            As per our record we found below contact informations. Please make sure everything looks good before proceeding to payment, since all booking details will be sent to the below email and phone number.
            
            If you want to make any changes, please update your profile section<br>
                            <br>
                            Role
            <select class="inputbox">
                <option>---Select----</option>
                <option selected>Parent</option>
                <option>Gaurdian</option>
            </select>
                            <br>
                            <br>
                            Parent/Gaurdian Name
            <input type="text" class="inputbox">
                            <br>
                            <br>
                            Email ID
            <input type="text" class="inputbox">
                            <br>
                            <br>
                            Mobile Number
            <input type="text" class="inputbox">
                            <br>
                            <br>
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-12 text-center mt-3">
                            <input name="" type="checkbox" value="">
                            By clicking the check box you are accepting the <a href="#">terms and condition</a> of Sparkles
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="admin-wrap">
                    <div class="admin-text p-3 w-100">Summary</div>
                    <br>
                    <ul class="s-price-list pl-4 pr-4 pt-4 pb-0">
                        <li class="bg1"><span>Child Name</span><br>
                            Andrews R (4 yrs)</li>
                        <li class="bg2"><span>Plan </span>
                            <br>
                            Flexible (3 Months)</li>
                        <li class="bg3"><span>Start Date</span><br>
                            October 06th  2022</li>
                    </ul>
                    <ul class="s-price">
                        <li>Plan cost (Fix Flex )</li>
                        <li class="text-right">&#x20b9; 5000</li>
                        <li>GST (18 %)</li>
                        <li class="text-right">&#x20b9; 900</li>
                    </ul>
                    <div class="text-center" style="width: 100%;">
                        <button class="s-price-btn">Pay &#x20b9; 5000</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="packages" role="dialog" data-backdrop="static">
        <div class="modal-dialog general-pop">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="create-title">Select Your package</div>
                    <button type="button" class="close p-0 m-0" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-3 p-0">
                            <ul class="pricing p-green">
                                <li class="one">
                                    <img src="" alt="">
                                    <big>Plans</big> </li>
                                <li>DURATION</li>
                                <li>Time Change</li>
                                <li>Flexibility</li>
                                <li>Day/Week Change</li>
                                <li>Cancellation</li>
                                <li>Package</li>
                                <li>Food</li>

                            </ul>
                        </div>
                        <div class="col-3 p-0">
                            <ul class="pricing p-yel">
                                <li class="two">
                                    <img src="" alt="">
                                    <big>Fixed</big> </li>
                                <li>20days x 2hrs</li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-no.png" /></li>
                                <li>
                                    <img src="../images/icon-no.png" /></li>
                                <li>One/Three Month</li>
                                <li>
                                    <img src="../images/icon-no.png" /></li>
                                <li>
                                    <h3>&#x20b9;5000</h3>
                                    <span>per month</span> </li>
                                <li>
                                    <button>Select</button>
                                </li>
                            </ul>
                        </div>
                        <div class="col-3 p-0">
                            <ul class="pricing p-red">
                                <li class="three">
                                    <img src="" alt="">
                                    <big>Flexible</big> </li>
                                <li>20days x 2hrs</li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>One/Three Month</li>
                                <li>
                                    <img src="../images/icon-no.png" /></li>
                                <li>
                                    <h3>&#x20b9;6000</h3>
                                    <span>per month</span> </li>
                                <li>
                                    <button>Select</button>
                                </li>
                            </ul>
                        </div>
                        <div class="col-3 p-0">
                            <ul class="pricing p-blue">
                                <li class="four">
                                    <img src="" alt="">
                                    <big>Corporate</big> </li>
                                <li>20days x 2hrs</li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>One/Three Month</li>
                                <li>
                                    <img src="../images/icon-yes.png" /></li>
                                <li>
                                    <h3>&#x20b9;7000</h3>
                                    <span>per month</span> </li>
                                <li>
                                    <button>Select</button>
                                </li>
                            </ul>
                        </div>
                        <!-- /block -->
                    </div>
                    <!-- /row -->
                </div>

            </div>
        </div>
    </div>
    <script src="js/jquery.datepicker2.js"></script>
    <script>
        $('#touchSlider').touchSlider({
            view: 3,
            gap: 20
        });
    </script>
    <script>

        var colorCodes = {
            pink: "#E91E63",
            indigo: "#3F51B5",
            cyan: "#00BCD4"
        };

        var radioButton = document.colorSelectorForm.colorSelector;
        var exampleText = document.getElementById('exampleText');
        var prev = null;

        if (prev === null) {
            exampleText.style.color = colorCodes[radioButton.value];
        }

        for (var i = 0; i < radioButton.length; i++) {
            radioButton[i].addEventListener('change', function () {
                if (this !== prev) {
                    prev = this;
                }
                exampleText.style.color = colorCodes[this.value];
            });
        }
    </script>
    <script>
        $(".time-slot-item").click(function () {
            $(this).toggleClass("picked");
        });
    </script>
</body>
</html>
