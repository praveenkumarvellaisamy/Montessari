<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Montessari.Login.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sparkles</title>

    <link href="../css/fontawesome.css" rel="stylesheet" />
    <link href="../css/Googleapis1.css" rel="stylesheet" />
    <link href="../css/Googleapis2.css" rel="stylesheet" />
    <link href="../css/Googleapis3.css" rel="stylesheet" />
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
            <div class="col-lg-3">
                <button class="btn-book" onclick="javascript:location.href='../Login/BookSlot.aspx'">
                    <img src="../images/bookicon.png" width="24" height="24" style="margin-top: -8px; margin-right: 10px;">BOOK YOUR SLOT</button>
                <div class="admin-wrap p-4">
                    <ul class="admin-menu">
                        <li><a href="../Login/Profile.aspx" class="active">
                            <img src="../images/menu-1.png" />My Profile</a></li>
                        <li><a href="../Login/ChildProfile.aspx">
                            <img src="../images/menu-2.png" />My Child Profile</a></li>
                        <li><a href="../Login/BookSlot.aspx">
                            <img src="../images/menu-3.png" />Book my slot</a></li>
                        <li><a href="#">
                            <img src="../images/menu-4.png" />Change Password</a></li>
                        <li><a href="#">
                            <img src="../images/menu-5.png" />Orders Details</a></li>
                        <li><a href="../Login/Login.aspx">
                            <img src="../images/menu-6.png" />Logout</a></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-9">
                <div class="admin-wrap">
                    <div class="admin-banner">
                        <div class="bannerimg">
                            <img src="../images/profileimage.jpg" /></div>
                        <input type="button" class="gen-btn" value="Edit" style="position: absolute; bottom: -50px; right: 20px;" data-toggle="modal" data-target="#edit-profile">
                    </div>
                    <div class="p-4">
                        <div class="row pl-4 pr-4">
                            <div class="col-lg-6 admin-list">First Name <span>Rebecca </span></div>
                            <div class="col-lg-6 admin-list">Last Name <span>Richard </span></div>
                            <div class="col-lg-6 admin-list">Phone Number <span>+91 91234 91234 </span></div>
                            <div class="col-lg-6 admin-list">Email ID <span>rebecca.richard@gmail.com </span></div>
                            <div class="col-lg-6 admin-list">Role <span>Parent </span></div>
                            <div class="col-lg-6 admin-list">Country <span>India </span></div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-lg-6"><span class="download-title">Your child information</span> </div>
                            <div class="col-lg-6">
                                <input type="button" class="gen-btn float-right" value="Add" data-toggle="modal" data-target="#add-child">
                            </div>
                            <div class="col-lg-11 mt-4 mb-4 ml-auto mr-auto">
                                <div id="touchSlider">
                                    <ul>
                                        <li class="vewprofile">
                                            <img src="../images/child1.jpg">
                                            <h1>Jenifer R</h1>
                                            <h2>2 Years old</h2>
                                            <button>View details</button>
                                            <h3>Enrolled</h3>
                                        </li>
                                        <li class="vewprofile">
                                            <img src="../images/child2.jpg">
                                            <h1>Andrews R</h1>
                                            <h2>4 Years old</h2>
                                            <button>View details</button>
                                        </li>
                                        <li class="vewprofile">
                                            <img src="../images/child3.jpg">
                                            <h1>Christina R</h1>
                                            <h2>8 Years old</h2>
                                            <button>View details</button>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="add-child" role="dialog" data-backdrop="static">
        <div class="modal-dialog general-pop">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="create-title">Add your Child</div>
                    <button type="button" class="close p-0 m-0" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-5 create-list">
                            <div class="profile-img text-center">
                                <div class="camera-icon"></div>
                                <img src="../images/child1.jpg">
                                <div class="phototype">
                                    Maximum size 200KB<br>
                                    Accepted file type: JPEG, PNG, SVG<br>
                                    Recently clicked photograph
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-7 create-list">
                            <ul class="add-child-controlwrap">
                                <li><span>First Name</span>
                                    <input type="text" class="inputbox" />
                                </li>
                                <li><span>Last Name</span>
                                    <input type="text" class="inputbox" />
                                </li>
                                <li><span>Date of Birth</span>
                                    <input type="text" class="inputbox cal" name="date" id="stdate" data-select="datepicker">
                                </li>
                                <li><span>Gender</span>
                                    <input name="" type="radio" value="">
                                    Male&nbsp;&nbsp;&nbsp;<input name="" type="radio" value="">
                                    Female
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <label style="color: #000; font-size: 14px; font-weight: 600">Write something interesting about your kid</label>
                            <br>
                            <textarea name="" cols="" rows="" class="textarea"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <input type="button" class="blue-btn" value="Add">
                    <input type="button" class="red-btn ml-2 red-btn" value="Cancel" data-dismiss="modal">
                </div>
            </div>
        </div>
    </div>





    <div class="modal fade" id="edit-profile" role="dialog" data-backdrop="static">
        <div class="modal-dialog general-pop">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="create-title">Edit your Profile</div>
                    <button type="button" class="close p-0 m-0" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-5 create-list">
                            <div class="profile-img text-center">
                                <div class="camera-icon"></div>
                                <img src="../images/profileimage.jpg">
                                <div class="phototype">
                                    Maximum size 200KB<br>
                                    Accepted file type: JPEG, PNG, SVG<br>
                                    Recently clicked photograph
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-7 create-list">
                            <ul class="add-child-controlwrap">
                                <li><span>First Name</span>
                                    <input type="text" class="inputbox" value="Rebecca" va />
                                </li>
                                <li><span>Last Name</span>
                                    <input type="text" class="inputbox" value="Richard" />
                                </li>
                                <li><span>Phone Number</span>
                                    <input type="text" class="inputbox" value="+91 91234 91234" />
                                </li>
                                <li><span>Email ID</span>
                                    <input type="text" class="inputbox" value="rebecca.richard@gmail.com" />
                                </li>
                                <li><span>Role</span>
                                    <select class="inputbox">
                                        <option>---Select----</option>
                                        <option selected>Parent</option>
                                        <option>Gaurdian</option>
                                    </select>
                                </li>
                                <li><span>Country</span>
                                    <select class="inputbox">
                                        <option>---Select----</option>
                                        <option selected>India</option>
                                        <option>Australia</option>
                                    </select>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <input type="button" class="blue-btn" value="Add">
                    <input type="button" class="red-btn ml-2 red-btn" value="Cancel" data-dismiss="modal">
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
</body>
</html>
