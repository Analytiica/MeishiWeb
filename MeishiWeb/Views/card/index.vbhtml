@Imports MeishiWeb.MeishiWeb.Extentions

@ModelType MeishiWeb.MeishiWeb.Models.CardInfoView

@Code
	Layout = Nothing

End Code


    <!DOCTYPE html>

        <html>

        <head>
            <meta charset="UTF-8" />
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <meta name="robots" content="noindex">
           

            <link rel="apple-touch-icon" sizes="57x57" type="image/png"
                  href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)">
            <link rel="apple-touch-icon" sizes="72x72" type="image/png"
                  href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)">
            <link rel="apple-touch-icon" sizes="114x114" type="image/png"
                  href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)">
            <link rel="apple-touch-icon" sizes="144x144" type="image/png"
                  href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)">
            <link rel="preload shortcut icon"
                  href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)" as="image"
                  type="image/x-icon">
            <link rel="apple-touch-icon" type="image/png" href="@String.Format("{0}/profilepicturesicons/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)">

    

            <title>@Model.CardInfoViews.FirstName @Model.CardInfoViews.LastName</title>


            <link rel="stylesheet" type="text/css" href="@String.Format("{0}/css/style.css", Model.CardInfoViews.ProfilePic)" />
            <link rel="stylesheet" type="text/css" href="/Views/card/assets/css/main.css?v1.2" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />


            
       
            <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
            <script src="/Views/card/assets/jquery-ui-1.12.1/jquery-ui.min.js"></script>
            <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
            <script src="https://code.jquery.com/mobile/1.5.0-alpha.1/jquery.mobile-1.5.0-alpha.1.min.js"></script>
            <script src='https://kit.fontawesome.com/a076d05399.js'></script>
            <script src="https://kit.fontawesome.com/548c7e4a21.js" crossorigin="anonymous"></script>

        </head>

        <body>

            <div id="mobileChecker"><div class="isMobile"></div></div>
            <div class="container">
                <!--splitlayout -->
                <div id="splitlayout" class="splitlayout">
                    <div class="intro">
                        <!--slide left-->
                        <div class="side side-left">
                            <div class="leftblock">
                                <div class="aboutme">
                                    <p> About me</p>
                                    <div class="abouticon">
                                        <div data-tags="chevron, navigation" data-pack="android">
                                            <i class="fas fa-arrow-left" style="line-height: 3"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="intro-content">
                                    <p>@Model.CardInfoViews.Introduction</p>
                                    <h1> <span>@Model.CardInfoViews.FirstName<br />@Model.CardInfoViews.LastName</span><span>@Model.CardInfoViews.JobTitle</span></h1>
                                    <div class="botnav botnav-right">
                                        <ul class="nav">
                                            <li><a href="#about" class="hvr-sweep-to-left">About</a></li>
                                            <!-- li><a href="#skills" class="hvr-sweep-to-left">My skills</a></li> -->
                                            <li> <a href="#contact" class="hvr-sweep-to-left">contact</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="footer">
                                    Powered by <a href="https://meishi.me/card/Meishi/BruceCurnick" target="_blank">Meishi.me</a>

                                </div>
                            </div>
                            <div class="overlay"></div>
                        </div>      <!--/slide left-->
                        <!--slide right-->
                        <div class="side side-right" style="background-image: Url('@String.Format("{0}/companypictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.CompanyID)'); background-repeat: no-repeat; background-position: center top;">

                            <div Class="background"></div>
                            <div class="rightblock">
                                <div class="portfolio">
                                    <p> Services</p>
                                    <div class="portfolioicon">
                                        <div data-tags="chevron, navigation" data-pack="android">
                                            <i class="fas fa-arrow-right" style="line-height: 3"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="intro-content">
                                    <p>@Model.CardInfoViews.Introduction</p>
                                    <h1>@Model.CardInfoViews.DisplayName</h1>
                                    <h1>@Model.CardInfoViews.JobTitle</h1>
                                    <div class="botnav botnav-left">
                                        <ul class="nav">
                                            <li class="active"><a href="#portfolio" class="hvr-sweep-to-left">Services</a></li>
                                            <!--li><a href="#resume" class="hvr-sweep-to-left">My resume</a></li> -->
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="overlay"></div>
                        </div>      <!-- /slide right-->
                    </div>
                    <!-- page-right -->
                    <div class="page page-right" style="background-color:#000000 !important;">
                        <!-- page-inner -->
                        <!-- page-inner -->
                        <div class="page-inner">
                            <section id="portfolio" class="pad200 padtop">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h2></h2>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="portfoliosec">
                                            <div class="gallery clearfix">
                                                <div class="grid">
                                                    <div class="row">
                                                        @If Model.LinkInfoViews.Title1 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title1)" />
                                                                    <h4>@Model.LinkInfoViews.Title1</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title1" Class="fancybox" name="" href="@Model.LinkInfoViews.LinkName1" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title2 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title2)" />
                                                                    <h4>@Model.LinkInfoViews.Title2</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title2" Class="fancybox" href="@Model.LinkInfoViews.LinkName2" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title3 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title3)" />
                                                                    <h4>@Model.LinkInfoViews.Title3</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title3" Class="fancybox" href="@Model.LinkInfoViews.LinkName3" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title4 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title4)" />
                                                                    <h4>@Model.LinkInfoViews.Title4</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title4" Class="fancybox" href="@Model.LinkInfoViews.LinkName4" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                        @If Model.LinkInfoViews.Title5 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title5)" />
                                                                    <h4>@Model.LinkInfoViews.Title5</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title5" Class="fancybox" href="@Model.LinkInfoViews.LinkName5" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                        @If Model.LinkInfoViews.Title6 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title6)" />
                                                                    <h4>@Model.LinkInfoViews.Title6</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title6" Class="fancybox" href="@Model.LinkInfoViews.LinkName6" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title7 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title7)" />
                                                                    <h4>@Model.LinkInfoViews.Title7</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title7" Class="fancybox" href="@Model.LinkInfoViews.LinkName7" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                        @If Model.LinkInfoViews.Title8 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title8)" />
                                                                    <h4>@Model.LinkInfoViews.Title8</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title8" Class="fancybox" href="@Model.LinkInfoViews.LinkName8" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title9 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title9)" />
                                                                    <h4>@Model.LinkInfoViews.Title9</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title9" Class="fancybox" href="@Model.LinkInfoViews.LinkName9" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title10 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title10)" />
                                                                    <h4>@Model.LinkInfoViews.Title10</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title10" Class="fancybox" href="@Model.LinkInfoViews.LinkName10" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                        @If Model.LinkInfoViews.Title11 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title11)" />
                                                                    <h4>@Model.LinkInfoViews.Title11</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title11" Class="fancybox" href="@Model.LinkInfoViews.LinkName11" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                        @If Model.LinkInfoViews.Title12 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title12)" />
                                                                    <h4>@Model.LinkInfoViews.Title12</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title12" Class="fancybox" href="@Model.LinkInfoViews.LinkName12" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title13 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title13)" />
                                                                    <h4>@Model.LinkInfoViews.Title13</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title13" Class="fancybox" href="@Model.LinkInfoViews.LinkName13" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title14 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title14)" />
                                                                    <h4>@Model.LinkInfoViews.Title14</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title14" Class="fancybox" href="@Model.LinkInfoViews.LinkName14" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
														End If
                                                        @If Model.LinkInfoViews.Title15 IsNot Nothing Then
                                                            @<div Class="col-lg-4 col-xs-6">
                                                                <figure Class="effect-apollo" style="box-shadow: inset 0 0 0 0 #182b8a;">
                                                                    <img src="@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title15)" />
                                                                    <h4>@Model.LinkInfoViews.Title15</h4>
                                                                    <p></p>
                                                                    <figcaption> <a id="@Model.LinkInfoViews.Title15" Class="fancybox" href="@Model.LinkInfoViews.LinkName15" data-fancybox-group="gallery" target="_blank"></a></figcaption>
                                                                </figure>
                                                            </div>
                                                        End If
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <!-- /page-inner -->      <!-- /page-inner -->
                    </div>
                    <!-- /page-right -->
                    <!-- page-left -->
                    <div class="page page-left">
                        <!-- page-inner -->
                        <div class="page-inner">
                            <section id="about">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="about">
                                            <h2>@Model.CardInfoViews.Introduction @Model.CardInfoViews.Alias</h2>
                                            <div class="imgsec">
                                                <img class="img-fluid" height="254" width="254"
                                                     src="@String.Format(" {0}/profilepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.CardInfoViews.DetailID)"
                                                     alt="@Model.CardInfoViews.DisplayName">
                                            </div>
                                            <div class="left_sec">
                                                <p class="font700">@Model.CardInfoViews.Bio</p>
                                                <p></p>
                                                <p></p>
                                                <a href="#contact1" class="hvr-rectangle-in download_button">Request a Call Back</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </section>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <section id="contact">
                                        <h2>Get in Touch</h2>
                                        <br>
                                        <p> Contact me for any questions or enquiries you may have.</p>
                                        <p class="font600">
                                            <a id="SendMail" name="email" Class="contact-details-link" href="mailto:@Model.CardInfoViews.email">@Model.CardInfoViews.email</a><br> <a id="MobileNumber" href="tel:@Model.CardInfoViews.MobileNumber">@Model.CardInfoViews.MobileNumber</a>
                                            <br>
                                            <a href="tel:@Model.CardInfoViews.LandLineNumber">@Model.CardInfoViews.LandLineNumber</a>
                                            <br> @Model.CardInfoViews.StreetName
                                            <br> @Model.CardInfoViews.AddressLine
                                            <br> @Model.CardInfoViews.Province
                                            <br> @Model.CardInfoViews.Country  
                                        </p>
                                        @If Model.CardInfoViews.Location IsNot Nothing Then
                                            @<a id="Maps" name="viewMap" Class="contact-details-link" href="@Model.CardInfoViews.Location" target="_blank">Click To view On maps.</a>
										End If
                                        <br>
                                        <div Class="social_icon">
                                            @If Model.CardInfoViews.Facebook IsNot Nothing Then
                                                @<a id="Facebook" href="@String.Format("{0}", Model.CardInfoViews.Facebook)" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fab fa-facebook" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.LinkedIn IsNot Nothing Then
                                                @<a id="LinkedIn" href="@Model.CardInfoViews.LinkedIn" name="LinkedIn" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fab fa-linkedin" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.Instagram IsNot Nothing Then
                                                @<a id="Instagram" href="@Model.CardInfoViews.Instagram" name="Instagram" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fab fa-instagram" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.YouTube IsNot Nothing Then
                                                @<a id="YouTube" href="@Model.CardInfoViews.YouTube" name="YouTube" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fab fa-youtube" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.Twitter IsNot Nothing Then
                                                @<a id="Twitter" href="@Model.CardInfoViews.Twitter" name="Twitter" Class="hvr-shutter-In-vertical contact-details-link"><i Class="fab fa-twitter"></i></a>
                                            End If
                                            @If Model.CardInfoViews.WebSite IsNot Nothing Then
                                                @<a id="WebSite" href="@Model.CardInfoViews.WebSite" name="WebSite" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fas fa-link" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.Location IsNot Nothing Then
                                                @<a id="MapMarker" href="@Model.CardInfoViews.Location" target="_blank" name="Map" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fas fa-map-marker" style="line-height: 2"></i></a>
                                            End If
                                            @If Model.CardInfoViews.MobileNumber IsNot Nothing Then
                                                @<a id="WhatsAppText" href="//api.whatsapp.com/send?phone=@Model.CardInfoViews.MobileNumber&text=" target="_blank" name="WhatsAppText" Class="hvr-shutter-in-vertical contact-details-link"><i Class="fab fa-whatsapp" style="line-height: 2"></i></a>
											End If

                                        </div>
                                        <p> <a id = "ContactSave" name="saveContact" Class="btn btn-success btn-lg contact-details-link" style="background-color: #000000 !important; border-color: #000000 !important;" href="@String.Format("https://meishi.me/card/contact/{0}/{1}", Model.CardInfoViews.CompanyID, Model.CardInfoViews.DetailID)" ) target="_blank" role="button">Save to Contacts</a></p>
                                        @*<p> <a name="saveContact" Class="btn btn-success btn-lg contact-details-link" style="background-color: #000000 !important; border-color: #000000 !important;" href=("https://meishi.me/" @Model.CardInfoViews.ProfilePic & "/contact/" & @Model.CardInfoViews.FirstName & @Model.CardInfoViews.LastName & ".vcf") role="button">Save to Contacts</a></p>*@
                                        <p> <a id="WhatsApp" name="whatsappShare" Class="btn btn-success btn-lg contact-details-link" style="background-color:   #000000 !important; border-color: #000000 !important;" href="whatsapp://send?text=@String.Format("https://meishi.me/card/{0}/{1}", Model.CardInfoViews.CompanyID, Model.CardInfoViews.DetailID)" data-action="share/whatsapp/share">Share via Whatsapp</a></p>
                                        <p id="contact1" Class="nomargin">Fill the form below for a quick callback</p>
                                        @*<form name="contactform" action="@String.Format("/Views/card/SendMail/{0}{1}{2}", Model.CardInfoViews.CompanyID, Model.CardInfoViews.FirstName, Model.CardInfoViews.LastName)" method="post">*@
                                        <form name="contactform" action="@Url.Action("SendMail", "card", New With {.tomail = Model.CardInfoViews.email, .company = Model.CardInfoViews.CompanyID, .firstname = Model.CardInfoViews.FirstName, .lastname = Model.CardInfoViews.LastName})" method="post">
                                            <input name="name" type="text" Class="inputbg" placeholder="Your name" required>
                                            <input name="email" type="email" Class="inputbg" placeholder="Your email" required>
                                            <input name="phone" type="text" Class="inputbg" placeholder="Your phone" required>
                                            <textarea name="message" Class="textareabg" placeholder="Your message"></textarea>
                                            <Button type="Submit" Class="hvr-rectangle-in send_button">Send</Button>

                                        </form>
                                    </section>
                                </div>
                            </div>
                        </div>      <!-- /page-inner -->
                    </div>

                    '<!-- /page-left -->
                    <a href="#" Class="back back-right hvr-pulse" title=" ">&rarr;</a>
                    <a href="#" Class="back back-left hvr-pulse" title=" ">&larr;</a>
                    @If Model.CardInfoViews.PersonBot IsNot Nothing Then
                        @<a href=@Model.CardInfoViews.PersonBot Class="float" target="_blank">
                            <i Class="far fa-comment-dots my-float"></i>
                        </a>
                        @<strong Class="float-text">Chat Here!</strong>
					Else
						If Model.CardInfoViews.CompanyBot IsNot Nothing Then
                            @<a href=@Model.CardInfoViews.CompanyBot Class="float" target="_blank">
                                <i Class="far fa-comment-dots my-float"></i>
                            </a>
                            @<strong Class="float-text">Chat Here!</strong>
						End If
					End If
                </div>
                '<!-- /splitlayout -->
            </div>


            <!--other imports-->
            <Script src="/Views/card/assets/js/service/AnalyticalService.js"></Script>
            <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
            <Script src="/Views/card/assets/js/plugins/jquery.appear.min.js"></Script>
            <Script src="/Views/card/assets/js/plugins/jquery.easing.1.3.min.js"></Script>
            <Script src="/Views/card/assets/js/plugins/modernizr.custom.min.js"></Script>
            <Script src="/Views/card/assets/js/plugins/jquery.countTo.min.js"></Script>
            <Script type="text/javascript" src="/Views/card/assets/js/plugins/jquery.fancybox.min.js"></Script>
            <Script src="/Views/card/assets/bootstrap/js/bootstrap.min.js"></Script>
            <Script src="/Views/card/assets/js/plugins/classie.min.js"></Script>
            <Script type="text/javascript" src="/Views/card/assets/js/plugins/jquery.scrollTo.min.js"></Script>
            <Script type="text/javascript" src="/Views/card/assets/js/plugins/jquery.localScroll.min.js"></Script>
            <Script src="/Views/card/assets/js/plugins/cbpSplitLayout.min.js"></Script>
            <Script src="/Views/card/assets/js/main.js"></Script>
            <Script src="/Views/card/assets/js/service/AnalyticalService.js"></Script>
            <Script src="/Views/card/assets/js/swipe.js"></Script>
            <script>
                $(document).ready(function() {setTimeout(function() {$(".ui-loader").hide(); }, 10);});
            </script>
            @*<Script>
                If('serviceWorker' in navigator) {
                    console.log("Will the service worker register?");
                    navigator.serviceWorker.register('service-worker.js')
                        .then(Function(reg) {
                            console.log("Yes, it did.");
                        }).catch(Function(err) {
                            console.log("No it didn't. This happened: ", err)
                        });
                }
            </Script>*@
        </body>
    </html>
    





