@ModelType MeishiWeb.MeishiWeb.Models.InsertView
@Imports MeishiWeb.MeishiWeb.Extentions

@Code
	ViewData("Title") = "Test"
End Code

<!DOCTYPE html>

<head>
	<meta charset="UTF-8">
	<title>Form</title>
	<link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
	<link rel="stylesheet" type="text/css" href="Content/style.css" />
	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
	<script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
	<script src="http://code.jquery.com/jquery-3.2.1.min.js"></script>
	<script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.7/jquery.validate.min.js"></script>
	<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
</head>



@Using Html.BeginForm("Finish", "Agent", FormMethod.Post, New With {.enctype = "multipart/form-data"})

	@Html.AntiForgeryToken()

	@<text>




		<div class="container">
			<ul class="nav nav-tabs" role="tablist">
				<li class="active"><div class="tabNavOverLay disabled"></div><a data-toggle="tab" href="#home">Company Information</a></li>
				<li><div class="tabNavOverLay disabled"></div><a data-toggle="tab" href="#menu1" class="tabDisable">User Information</a></li>
				<li><div class="tabNavOverLay disabled"></div><a data-toggle="tab" href="#menu2" disabled="disable">User Profile</a></li>
				<li> <div class="tabNavOverLay disabled"></div><a data-toggle="tab" href="#menu3" disabled="disable">Completed</a></li>
			</ul>

			
				<div class="tab-content">
						<div id="home" class="tab-pane fade in active">
							<h3>Company Information</h3>
							<div class="form-group">
								@Html.LabelFor(Function(model) model.CompanyName, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.CompanyName, New With {.htmlAttributes = New With {.class = "form-control", .id = "company", .value = Model.CompanyName}})
									@Html.ValidationMessageFor(Function(model) model.CompanyName, "", New With {.class = "text-danger"})


								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.StreetName, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.StreetName, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.StreetName, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.AddressLine, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.AddressLine, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.AddressLine, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.Province, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.Province, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.Province, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.PostalCode, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.PostalCode, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.PostalCode, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.Country, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									<select id="country" name="country" class="form-control">
										<option value="Country">Country</option>
										<option value="Afghanistan">Afghanistan</option>
										<option value="Åland Islands">Åland Islands</option>
										<option value="Albania">Albania</option>
										<option value="Algeria">Algeria</option>
										<option value="American Samoa">American Samoa</option>
										<option value="Andorra">Andorra</option>
										<option value="Angola">Angola</option>
										<option value="Anguilla">Anguilla</option>
										<option value="Antarctica">Antarctica</option>
										<option value="Antigua and Barbuda">Antigua and Barbuda</option>
										<option value="Argentina">Argentina</option>
										<option value="Armenia">Armenia</option>
										<option value="Aruba">Aruba</option>
										<option value="Australia">Australia</option>
										<option value="Austria">Austria</option>
										<option value="Azerbaijan">Azerbaijan</option>
										<option value="Bahamas">Bahamas</option>
										<option value="Bahrain">Bahrain</option>
										<option value="Bangladesh">Bangladesh</option>
										<option value="Barbados">Barbados</option>
										<option value="Belarus">Belarus</option>
										<option value="Belgium">Belgium</option>
										<option value="Belize">Belize</option>
										<option value="Benin">Benin</option>
										<option value="Bermuda">Bermuda</option>
										<option value="Bhutan">Bhutan</option>
										<option value="Bolivia">Bolivia</option>
										<option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
										<option value="Botswana">Botswana</option>
										<option value="Bouvet Island">Bouvet Island</option>
										<option value="Brazil">Brazil</option>
										<option value="British Indian Ocean Territory">British Indian Ocean Territory</option>
										<option value="Brunei Darussalam">Brunei Darussalam</option>
										<option value="Bulgaria">Bulgaria</option>
										<option value="Burkina Faso">Burkina Faso</option>
										<option value="Burundi">Burundi</option>
										<option value="Cambodia">Cambodia</option>
										<option value="Cameroon">Cameroon</option>
										<option value="Canada">Canada</option>
										<option value="Cape Verde">Cape Verde</option>
										<option value="Cayman Islands">Cayman Islands</option>
										<option value="Central African Republic">Central African Republic</option>
										<option value="Chad">Chad</option>
										<option value="Chile">Chile</option>
										<option value="China">China</option>
										<option value="Christmas Island">Christmas Island</option>
										<option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
										<option value="Colombia">Colombia</option>
										<option value="Comoros">Comoros</option>
										<option value="Congo">Congo</option>
										<option value="Congo, The Democratic Republic of The">Congo, The Democratic Republic of The</option>
										<option value="Cook Islands">Cook Islands</option>
										<option value="Costa Rica">Costa Rica</option>
										<option value="Cote D'ivoire">Cote D'ivoire</option>
										<option value="Croatia">Croatia</option>
										<option value="Cuba">Cuba</option>
										<option value="Cyprus">Cyprus</option>
										<option value="Czech Republic">Czech Republic</option>
										<option value="Denmark">Denmark</option>
										<option value="Djibouti">Djibouti</option>
										<option value="Dominica">Dominica</option>
										<option value="Dominican Republic">Dominican Republic</option>
										<option value="Ecuador">Ecuador</option>
										<option value="Egypt">Egypt</option>
										<option value="El Salvador">El Salvador</option>
										<option value="Equatorial Guinea">Equatorial Guinea</option>
										<option value="Eritrea">Eritrea</option>
										<option value="Estonia">Estonia</option>
										<option value="Ethiopia">Ethiopia</option>
										<option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
										<option value="Faroe Islands">Faroe Islands</option>
										<option value="Fiji">Fiji</option>
										<option value="Finland">Finland</option>
										<option value="France">France</option>
										<option value="French Guiana">French Guiana</option>
										<option value="French Polynesia">French Polynesia</option>
										<option value="French Southern Territories">French Southern Territories</option>
										<option value="Gabon">Gabon</option>
										<option value="Gambia">Gambia</option>
										<option value="Georgia">Georgia</option>
										<option value="Germany">Germany</option>
										<option value="Ghana">Ghana</option>
										<option value="Gibraltar">Gibraltar</option>
										<option value="Greece">Greece</option>
										<option value="Greenland">Greenland</option>
										<option value="Grenada">Grenada</option>
										<option value="Guadeloupe">Guadeloupe</option>
										<option value="Guam">Guam</option>
										<option value="Guatemala">Guatemala</option>
										<option value="Guernsey">Guernsey</option>
										<option value="Guinea">Guinea</option>
										<option value="Guinea-bissau">Guinea-bissau</option>
										<option value="Guyana">Guyana</option>
										<option value="Haiti">Haiti</option>
										<option value="Heard Island and Mcdonald Islands">Heard Island and Mcdonald Islands</option>
										<option value="Holy See (Vatican City State)">Holy See (Vatican City State)</option>
										<option value="Honduras">Honduras</option>
										<option value="Hong Kong">Hong Kong</option>
										<option value="Hungary">Hungary</option>
										<option value="Iceland">Iceland</option>
										<option value="India">India</option>
										<option value="Indonesia">Indonesia</option>
										<option value="Iran, Islamic Republic of">Iran, Islamic Republic of</option>
										<option value="Iraq">Iraq</option>
										<option value="Ireland">Ireland</option>
										<option value="Isle of Man">Isle of Man</option>
										<option value="Israel">Israel</option>
										<option value="Italy">Italy</option>
										<option value="Jamaica">Jamaica</option>
										<option value="Japan">Japan</option>
										<option value="Jersey">Jersey</option>
										<option value="Jordan">Jordan</option>
										<option value="Kazakhstan">Kazakhstan</option>
										<option value="Kenya">Kenya</option>
										<option value="Kiribati">Kiribati</option>
										<option value="Korea, Democratic People's Republic of">Korea, Democratic People's Republic of</option>
										<option value="Korea, Republic of">Korea, Republic of</option>
										<option value="Kuwait">Kuwait</option>
										<option value="Kyrgyzstan">Kyrgyzstan</option>
										<option value="Lao People's Democratic Republic">Lao People's Democratic Republic</option>
										<option value="Latvia">Latvia</option>
										<option value="Lebanon">Lebanon</option>
										<option value="Lesotho">Lesotho</option>
										<option value="Liberia">Liberia</option>
										<option value="Libyan Arab Jamahiriya">Libyan Arab Jamahiriya</option>
										<option value="Liechtenstein">Liechtenstein</option>
										<option value="Lithuania">Lithuania</option>
										<option value="Luxembourg">Luxembourg</option>
										<option value="Macao">Macao</option>
										<option value="Macedonia, The Former Yugoslav Republic of">Macedonia, The Former Yugoslav Republic of</option>
										<option value="Madagascar">Madagascar</option>
										<option value="Malawi">Malawi</option>
										<option value="Malaysia">Malaysia</option>
										<option value="Maldives">Maldives</option>
										<option value="Mali">Mali</option>
										<option value="Malta">Malta</option>
										<option value="Marshall Islands">Marshall Islands</option>
										<option value="Martinique">Martinique</option>
										<option value="Mauritania">Mauritania</option>
										<option value="Mauritius">Mauritius</option>
										<option value="Mayotte">Mayotte</option>
										<option value="Mexico">Mexico</option>
										<option value="Micronesia, Federated States of">Micronesia, Federated States of</option>
										<option value="Moldova, Republic of">Moldova, Republic of</option>
										<option value="Monaco">Monaco</option>
										<option value="Mongolia">Mongolia</option>
										<option value="Montenegro">Montenegro</option>
										<option value="Montserrat">Montserrat</option>
										<option value="Morocco">Morocco</option>
										<option value="Mozambique">Mozambique</option>
										<option value="Myanmar">Myanmar</option>
										<option value="Namibia">Namibia</option>
										<option value="Nauru">Nauru</option>
										<option value="Nepal">Nepal</option>
										<option value="Netherlands">Netherlands</option>
										<option value="Netherlands Antilles">Netherlands Antilles</option>
										<option value="New Caledonia">New Caledonia</option>
										<option value="New Zealand">New Zealand</option>
										<option value="Nicaragua">Nicaragua</option>
										<option value="Niger">Niger</option>
										<option value="Nigeria">Nigeria</option>
										<option value="Niue">Niue</option>
										<option value="Norfolk Island">Norfolk Island</option>
										<option value="Northern Mariana Islands">Northern Mariana Islands</option>
										<option value="Norway">Norway</option>
										<option value="Oman">Oman</option>
										<option value="Pakistan">Pakistan</option>
										<option value="Palau">Palau</option>
										<option value="Palestinian Territory, Occupied">Palestinian Territory, Occupied</option>
										<option value="Panama">Panama</option>
										<option value="Papua New Guinea">Papua New Guinea</option>
										<option value="Paraguay">Paraguay</option>
										<option value="Peru">Peru</option>
										<option value="Philippines">Philippines</option>
										<option value="Pitcairn">Pitcairn</option>
										<option value="Poland">Poland</option>
										<option value="Portugal">Portugal</option>
										<option value="Puerto Rico">Puerto Rico</option>
										<option value="Qatar">Qatar</option>
										<option value="Reunion">Reunion</option>
										<option value="Romania">Romania</option>
										<option value="Russian Federation">Russian Federation</option>
										<option value="Rwanda">Rwanda</option>
										<option value="Saint Helena">Saint Helena</option>
										<option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
										<option value="Saint Lucia">Saint Lucia</option>
										<option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
										<option value="Saint Vincent and The Grenadines">Saint Vincent and The Grenadines</option>
										<option value="Samoa">Samoa</option>
										<option value="San Marino">San Marino</option>
										<option value="Sao Tome and Principe">Sao Tome and Principe</option>
										<option value="Saudi Arabia">Saudi Arabia</option>
										<option value="Senegal">Senegal</option>
										<option value="Serbia">Serbia</option>
										<option value="Seychelles">Seychelles</option>
										<option value="Sierra Leone">Sierra Leone</option>
										<option value="Singapore">Singapore</option>
										<option value="Slovakia">Slovakia</option>
										<option value="Slovenia">Slovenia</option>
										<option value="Solomon Islands">Solomon Islands</option>
										<option value="Somalia">Somalia</option>
										<option value="South Africa">South Africa</option>
										<option value="South Georgia and The South Sandwich Islands">South Georgia and The South Sandwich Islands</option>
										<option value="Spain">Spain</option>
										<option value="Sri Lanka">Sri Lanka</option>
										<option value="Sudan">Sudan</option>
										<option value="Suriname">Suriname</option>
										<option value="Svalbard and Jan Mayen">Svalbard and Jan Mayen</option>
										<option value="Swaziland">Swaziland</option>
										<option value="Sweden">Sweden</option>
										<option value="Switzerland">Switzerland</option>
										<option value="Syrian Arab Republic">Syrian Arab Republic</option>
										<option value="Taiwan, Province of China">Taiwan, Province of China</option>
										<option value="Tajikistan">Tajikistan</option>
										<option value="Tanzania, United Republic of">Tanzania, United Republic of</option>
										<option value="Thailand">Thailand</option>
										<option value="Timor-leste">Timor-leste</option>
										<option value="Togo">Togo</option>
										<option value="Tokelau">Tokelau</option>
										<option value="Tonga">Tonga</option>
										<option value="Trinidad and Tobago">Trinidad and Tobago</option>
										<option value="Tunisia">Tunisia</option>
										<option value="Turkey">Turkey</option>
										<option value="Turkmenistan">Turkmenistan</option>
										<option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
										<option value="Tuvalu">Tuvalu</option>
										<option value="Uganda">Uganda</option>
										<option value="Ukraine">Ukraine</option>
										<option value="United Arab Emirates">United Arab Emirates</option>
										<option value="United Kingdom">United Kingdom</option>
										<option value="United States">United States</option>
										<option value="United States Minor Outlying Islands">United States Minor Outlying Islands</option>
										<option value="Uruguay">Uruguay</option>
										<option value="Uzbekistan">Uzbekistan</option>
										<option value="Vanuatu">Vanuatu</option>
										<option value="Venezuela">Venezuela</option>
										<option value="Viet Nam">Viet Nam</option>
										<option value="Virgin Islands, British">Virgin Islands, British</option>
										<option value="Virgin Islands, U.S.">Virgin Islands, U.S.</option>
										<option value="Wallis and Futuna">Wallis and Futuna</option>
										<option value="Western Sahara">Western Sahara</option>
										<option value="Yemen">Yemen</option>
										<option value="Zambia">Zambia</option>
										<option value="Zimbabwe">Zimbabwe</option>
									</select>
								</div>
							</div>


							@*<div class="form-group">
								@Html.LabelFor(Function(model) model.Company_moto, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.Company_moto, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.Company_moto, "", New With {.class = "text-danger"})
								</div>
							</div>*@


							<div class="form-group">
								@Html.LabelFor(Function(model) model.WebSite, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.WebSite, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.WebSite, "", New With {.class = "text-danger"})
								</div>
							</div>
							<div class="form-group">
								@Html.LabelFor(Function(model) model.LandLineNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.LandLineNumber, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LandLineNumber, "", New With {.class = "text-danger"})
								</div>
							</div>



							<div class="form-group">
								@Html.LabelFor(Function(model) model.FaxNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.FaxNumber, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.FaxNumber, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div class="form-group">
								@Html.LabelFor(Function(model) model.CompanyBot, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div class="col-md-10">
									@Html.EditorFor(Function(model) model.CompanyBot, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.CompanyBot, "", New With {.class = "text-danger"})
								</div>
							</div>


							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName1, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title1, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName1, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName1, "", New With {.class = "text-danger"})

								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName2, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title2, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName2, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName2, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName3, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title3, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName3, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName3, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName4, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title4, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName4, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName4, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName5, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title5, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName5, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName5, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName6, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title6, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName6, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName6, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName7, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title7, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName7, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName7, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName8, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title8, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName8, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName8, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName9, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title9, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName9, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName9, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName10, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title10, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName10, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName10, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName11, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title11, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName11, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName11, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName12, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title12, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName12, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName12, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName13, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title13, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName13, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName13, "", New With {.class = "text-danger"})
								</div>
							</div>

							<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName14, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title14, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName14, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName14, "", New With {.class = "text-danger"})
								</div>
							</div>

							@*<div Class="form-group">

								@Html.LabelFor(Function(model) model.LinkName15, htmlAttributes:=New With {.class = "control-label col-md-2"})
								<div Class="col-md-10">
									<div class="form-inline">
										@Html.EditorFor(Function(model) model.Title15, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link", .id = "link15", .value = "Scan my Meishi"}})
									</div>
									@Html.EditorFor(Function(model) model.LinkName15, New With {.htmlAttributes = New With {.class = "form-control"}})
									@Html.ValidationMessageFor(Function(model) model.LinkName15, "", New With {.class = "text-danger"})
								</div>
							</div>*@
							<div class="col-sm-12 next-button">
								<button id="homeTabButton" type="button" class="btn btn-primary">Next</button>
							</div>

						</div>

					<!--            tab 1 -->

					<div id="menu1" class="tab-pane fade">
						<h3>User Information</h3>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.FirstName, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.FirstName, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.FirstName, "", New With {.class = "text-danger"})
							</div>
						</div>

						@*<div class="form-group">
							@Html.LabelFor(Function(model) model.MiddleName, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.MiddleName, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.MiddleName, "", New With {.class = "text-danger"})
							</div>
						</div>*@

						<div class="form-group">
							@Html.LabelFor(Function(model) model.LastName, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.LastName, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.LastName, "", New With {.class = "text-danger"})
							</div>
						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.Alias, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Alias, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Alias, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.JobTitle, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.JobTitle, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.JobTitle, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.Bio, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Bio, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Bio, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div id="map" class="form-group">
							@Html.LabelFor(Function(model) model.Location, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								<input class="form-control" type="text" id="autocomplete" />
								@Html.ValidationMessageFor(Function(model) model.Location, "", New With {.class = "text-danger"})
							</div>
							<div style="display:none">
								@Html.EditorFor(Function(model) model.Location, New With {.htmlAttributes = New With {.Class = "form-control", .id = "autocompletevalue"}})
							</div>

						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.email, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.email, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.email, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.MobileNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.MobileNumber, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.MobileNumber, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.Facebook, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Facebook, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Facebook, "", New With {.class = "text-danger"})
							</div>
						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.Instagram, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Instagram, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Instagram, "", New With {.class = "text-danger"})
							</div>
						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.YouTube, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.YouTube, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.YouTube, "", New With {.class = "text-danger"})
							</div>
						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.Twitter, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Twitter, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Twitter, "", New With {.class = "text-danger"})
							</div>
						</div>

						<div class="form-group">
							@Html.LabelFor(Function(model) model.LinkedIn, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.LinkedIn, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.LinkedIn, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.Introduction, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.Introduction, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.Introduction, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="form-group">
							@Html.LabelFor(Function(model) model.PersonBot, htmlAttributes:=New With {.class = "control-label col-md-2"})
							<div class="col-md-10">
								@Html.EditorFor(Function(model) model.PersonBot, New With {.htmlAttributes = New With {.class = "form-control"}})
								@Html.ValidationMessageFor(Function(model) model.PersonBot, "", New With {.class = "text-danger"})
							</div>
						</div>
						<div class="col-sm-12 next-button">
							<button type="button" class="btn btn-danger tabBackButton">Back</button>
							<button id="secondTabButton" type="button" class="btn btn-primary">Next</button>
						</div>

					</div>

					<!--            tab 2-->

					<div id="menu2" class="tab-pane fade">
						<h3>User Profile</h3>

						<div class="form-horizontal">
							<input id="src" type="file" name="file" />
							<img id="target" width="250" height="250" multiple />

						</div>

						<div class="col-sm-12 next-button">
							<button type="button" class="btn btn-danger tabBackButton">Back</button>

							<button id="thirdTabButton" type="button" class="btn btn-primary">Next</button>
						</div>

					</div>

					<!--            tab 3-->
					<div id="menu3" class="tab-pane fade">
						<h3>Select Company Image</h3>
						<div class="form-row col-lg-8">
							<div class="form-group ">

								<div class="form-horizontal">
									<input id="src1" type="file" name="file" />
									<img id="target1" width="1342" height="1000" multiple />

								</div>

							</div>

							<div class="col-sm-12 next-button">
								<button type="button" class="btn btn-danger tabBackButton">Back</button>
								<button type="submit" class="btn btn-primary" value="btnFinish" name="btnFinish">Finish</button>
								@Html.ActionLink("Create Antoher for Same Company", "Create", "Agent")
                            </div>
						</div>
					</div>


				</div>

			
		</div>

		<script>
			//<!---
			// next buttons

			//$(".tab-content1").on("change", function () {
			//	//alert("change");
			//	if (this.value == "") {
			//			//alert("true");
			//			var id_attr = "#" + $(this).attr("id") + "1";
			//			$(this).closest('.form-group').removeClass('has-success').addClass('has-error');
			//			$(id_attr).removeClass('glyphicon-ok').addClass('glyphicon-remove');
			//		}
			//		else {
			//			//alert("false");
			//			var id_attr = "#" + $(this).attr("id") + "1";
			//			$(this).closest('.form-group').removeClass('has-error').addClass('has-success');
			//			$(id_attr).removeClass('glyphicon-remove').addClass('glyphicon-ok');
			//		}
			//});




			$("#homeTabButton").on("click", function () {
				//$(".tab-content1").each(function () {
				//	//alert(this.value);
					
				//	if (this.value == "") {
				//		//alert("true");
				//		var id_attr = "#" + $(this).attr("id") + "1";
				//		$(this).closest('.form-group').removeClass('has-success').addClass('has-error');
				//		$(id_attr).removeClass('glyphicon-ok').addClass('glyphicon-remove');
				//	}
				//	else {
				//		//alert("false");
				//		var id_attr = "#" + $(this).attr("id") + "1";
				//		$(this).closest('.form-group').removeClass('has-error').addClass('has-success');
				//		$(id_attr).removeClass('glyphicon-remove').addClass('glyphicon-ok');
				//	}
				//});

				





				// can add a validation for this section before executing the next statement
				$('.nav-tabs > .active').next('li').find('a').trigger('click');
			});
			$("#secondTabButton").on("click", function () {
				// can add a validation for this section before executing the next statement
				$('.nav-tabs > .active').next('li').find('a').trigger('click');
			});
			$("#thirdTabButton").on("click", function () {
				// can add a validation for this section before executing the next statement
				$('.nav-tabs > .active').next('li').find('a').trigger('click');
			});
			// back buttons
			$(".tabBackButton").on("click", function () {
				$('.nav-tabs > .active').prev('li').find('a').trigger('click');
			});

			//--->
		</script>
		<script type="application/javascript" src="./Scripts/tabService.js"></script>
		@*<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCE_mbh8_fN_smr8f10YCU3I275ioPxwWU&libraries=places"></script>*@
		<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDeoUS-6udSQlJHw5mrBW3Vyr73v2fjvOU&libraries=places"></script>
		<script>

			function showImage(src, target) {
				var fr = new FileReader();
				// when image is loaded, set the src of the image where you want to display it
				fr.onload = function (e) { target.src = this.result; };
				src.addEventListener("change", function () {
					// fill fr with image data
					fr.readAsDataURL(src.files[0]);

				});
			}

			var src = document.getElementById("src");
			var target = document.getElementById("target");
			showImage(src, target);
			var src1 = document.getElementById("src1");
			var target1 = document.getElementById("target1");
			showImage(src1, target1);


		</script>

		<script>
			var input = document.getElementById('autocomplete');
			var output = document.getElementById('autocompletevalue');
			var autocomplete = new google.maps.places.Autocomplete(input);
			autocomplete.setFields(['place_id', 'geometry', 'name']);
			google.maps.event.trigger(this, 'focus', {});
			google.maps.event.addListener(autocomplete, 'place_changed', function () {
				var place = autocomplete.getPlace();
				//  alert(place.place_id);

				var link = 'https://www.google.com/maps/search/?api=1&query=' + place.geometry.location + '&query_place_id=' + place.place_id;
				//alert(link)
				output.value = link;
				//alert(output.value)

			})
		</script>





	</text>








End Using