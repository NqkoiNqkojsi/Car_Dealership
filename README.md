<?xml version="1.0"?>

-<doc>


-<assembly>

<name>CarDealership</name>

</assembly>


-<members>


-<member name="T:CarDealership.Controllers.CarBrandController">

<summary>Bussiness logic for CarBrand. </summary>

</member>


-<member name="M:CarDealership.Controllers.CarBrandController.GetBrands">

<summary>Get all registered brands. </summary>

<returns>Returns a list of all unique brands.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarBrandController.GetModelsByBrand(System.String)">

<summary>Get all the models that are in a certain brand </summary>

<returns>All models in a brand.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarBrandController.GetModels(System.String)">

<summary>Get all registered car models. </summary>

<param name="brand"/>

<returns>Returns a list of all unique .</returns>

</member>


-<member name="T:CarDealership.Controllers.CarController">

<summary>Bussiness logic for Car. </summary>

</member>


-<member name="M:CarDealership.Controllers.CarController.MakeDate(System.String)">

<summary>Make a date from a string with only month and year. </summary>

<param name="date">format=M.yyy :"10.2003"</param>

<returns>DateTime with only moth and year</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.AddFavoriteCar(System.Int32)">

<summary>Adds cars to customer's wish list. </summary>

<param name="carId">ids of liked cars</param>

</member>


-<member name="M:CarDealership.Controllers.CarController.RemoveFavoriteCar(System.Int32)">

<summary>Removes a car from Favorite cars. </summary>

<param name="carId">Car id.</param>

</member>


-<member name="M:CarDealership.Controllers.CarController.IsFavoriteCar(System.Int32)">

<summary>Checks if a car is in favorites. </summary>

<param name="carId">Car id.</param>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarController.ShowFavoriteCars">

<summary>Show Cars in the Customer's Wishlist </summary>

<returns>list of ids</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.ShowOwnedCars">

<summary>Show Cars in the Customer's Wishlist. </summary>

<returns>A list of ids.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.IDtoCarInfo(System.Int32)">

<summary>Returns info of car. </summary>

<param name="id">Id of needed car.</param>

<returns>Dictionary of necessary info.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.MakeImgDir(System.Int32)">

<summary>Creates a directory that contains a car's photos. </summary>

<param name="id"/>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarController.ImgDirString(System.Int32)">

<summary>Returns directory name for ease of the AddPhotoToDir method. </summary>

<param name="id"/>

<returns>Returns the directory as a string.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.ImageUpload">

<summary>Uploads an image to a customer's offer. </summary>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarController.AddPhotoToDir(System.Int32,Windows.Storage.StorageFile,System.String)">

<summary>Adds the image to a car's photo directory </summary>

<param name="id">Offer id.</param>

<param name="carPhoto">The file itself.</param>

<param name="num">The number with which to be saved.</param>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarController.PhotoInDirCount(System.Int32)">

<summary>Counts the number of images in a single directory. </summary>

<param name="id"/>

<returns>Returns the count.</returns>

</member>


-<member name="M:CarDealership.Controllers.CarController.PhotosAll(System.Int32)">

<summary>Creates a list of all photos. </summary>

<param name="id"/>

<returns>Returs a list of all cars.</returns>

</member>


-<member name="T:CarDealership.Controllers.CarsSortAndFilterController">

<summary>Bussiness logic for Sorting and Filtering. </summary>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarsFilterPrice(System.Collections.Generic.List{CarDealership.Models.Car},System.Double,System.Double)">

<summary>Find the cars in the given price range. </summary>

<param name="priceEnd">The max price</param>

<param name="priceStart">The min price (optional)</param>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarsSortPrice(System.Collections.Generic.List{CarDealership.Models.Car})">

<summary>Sort the cars by price. </summary>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarsFilterYear(System.Collections.Generic.List{CarDealership.Models.Car},System.Int32)">

<summary>Find the cars made after a given year. </summary>

<param name="year">The earliest year wanted</param>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarsSortYear(System.Collections.Generic.List{CarDealership.Models.Car})">

<summary>Sort the cars by age. </summary>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarFilterBrand(System.Collections.Generic.List{CarDealership.Models.Car},System.String)">

<summary>Find the cars with a specific brand. </summary>

<param name="brand">The searched brand.</param>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CarFilterBrandModel(System.Collections.Generic.List{CarDealership.Models.Car},CarDealership.Models.CarBrand)">

<summary>Find the cars with a certain model and brand. </summary>

<param name="carBrand">The brand and model as an object.</param>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CompleteFilter(System.Double,System.Double,System.String,System.Int32,System.String,System.String)">

<summary>Utilizes all of the filters. </summary>

<param name="price"/>

<param name="brand"/>

<param name="year"/>

<param name="model"/>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CarsSortAndFilterController.CompleteSort(System.String)">

<summary>Utilizes the other sorts. </summary>

<param name="choice">can be "Price", "Year" or "Price and Year"</param>

<returns/>

</member>


-<member name="T:CarDealership.Controllers.CustomerController">

<summary>Business Logic for the Customer. </summary>

</member>


-<member name="P:CarDealership.Controllers.CustomerController.sessionID">

<summary>Determines if the customer is logged in. (Is 0 if not) </summary>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.HashString(System.String)">

<summary>Safe Password Hashing w/ SHA512 </summary>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.RandomNumber(System.Int32,System.Int32)">

<summary>Random Number between 2 Endpoints </summary>

<param name="min"/>

<param name="max"/>

<returns/>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.RandomString(System.Int32,System.Boolean)">

<summary>Creates a random jumble of letters with specified size and upper/lowercase. </summary>

<param name="size"/>

<param name="lowerCase"/>

<returns>The string of random jumble of letters.</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.RandomPassword(System.Int32)">

<summary>Makes a random password out of numbers and letters </summary>

<param name="size"/>

<returns>The randomized password.</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.IsValidEmail(System.String)">

<summary>Checks Email Validity </summary>

<param name="email">potential email</param>

<returns>True or False.</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.IsValidPassword(System.String)">

<summary>Checks Password Validity </summary>

<param name="password">potential password</param>

<returns>True or Talse</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.MakeBirthDate(System.String)">

<summary>Make a date from a string </summary>

<param name="date">format=dd.M.yyy :"23.10.2003"</param>

<returns>DateTime with only a month and a year.</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.CreateCustomer(System.String,System.String,System.String,System.String,System.String)">

<summary>Registers a customer </summary>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.UpdatePassword(System.Int32,System.String,System.String)">

<summary>Redo Password </summary>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.SendEmail(System.String,System.String,System.String)">

<summary>Sends an email/offer about a car </summary>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.AddToFavorite(CarDealership.Models.Car)">

<summary>Adds a car to your wishlist/favorite cars </summary>

<param name="customer"/>

<param name="car"/>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.ForgottenPasswords(System.String)">

<summary>Sends you an email to recover your password </summary>

<param name="email"/>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.CreateOffer(System.String,System.String,System.Double,System.String,System.Double,System.Double,System.Double,System.String)">

<summary>Creates an offer for a car </summary>

<param name="brand"/>

<param name="model"/>

<param name="price"/>

<param name="manufDateStr"/>

<param name="horsePower"/>

<param name="kmDriven"/>

<param name="engineVolume"/>

<param name="info"/>

<returns>a response message</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.Login(System.String,System.String)">

<summary>Method to log in a customer. </summary>

<param name="email"/>

<param name="password"/>

<returns>Response message.</returns>

</member>


-<member name="M:CarDealership.Controllers.CustomerController.RemoveOffer(System.Int32)">

<summary>Removes the offer from customer's account. </summary>

<param id="id"/>

</member>


-<member name="T:CarDealership.Controllers.MockUpListsController">

<summary>Mock up bussiness. </summary>

</member>


-<member name="M:CarDealership.Controllers.MockUpListsController.GenerateMockUpCar(System.Int32)">

<summary>Creates a mock up car. </summary>

<param name="count"/>

<returns>A string of the result.</returns>

</member>


-<member name="F:CarDealership.Controllers.MockUpListsController.brandsReal">

<summary>Creates a list of existing brands. (To create better mock ups) </summary>

</member>


-<member name="M:CarDealership.Controllers.MockUpListsController.GenerateMockUpCarBrand(System.Int32)">

<summary>Creates a mock up car brand. </summary>

<param name="count"/>

<returns>A string of the result.</returns>

</member>


-<member name="M:CarDealership.Controllers.MockUpListsController.GenerateMockUpCustomer(System.Int32)">

<summary>Creates a mock up customer. </summary>

<param name="count"/>

<returns>A string of the result.</returns>

</member>


-<member name="T:CarDealership.Data.CarDealershipContext">

<summary>CarDealershipContext class. </summary>

</member>


-<member name="M:CarDealership.Data.CarDealershipContext.#ctor">

<summary>Constructor </summary>

</member>


-<member name="M:CarDealership.Data.CarDealershipContext.#ctor(Microsoft.EntityFrameworkCore.DbContextOptions{CarDealership.Data.CarDealershipContext})">

<summary>Constructor (overloaded). </summary>

<param name="options"/>

</member>


-<member name="P:CarDealership.Data.CarDealershipContext.carBrands">

<summary>CarBrands Table </summary>

</member>


-<member name="P:CarDealership.Data.CarDealershipContext.cars">

<summary>Cars Table </summary>

</member>


-<member name="P:CarDealership.Data.CarDealershipContext.customers">

<summary>Cars Table </summary>

</member>


-<member name="P:CarDealership.Data.CarDealershipContext.pictures">

<summary>CarBrands Table </summary>

</member>


-<member name="P:CarDealership.Data.CarDealershipContext.relationSeller">

<summary>Cars Table </summary>

</member>


-<member name="M:CarDealership.Data.CarDealershipContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)">

<summary>Connection string to Microsoft SQL Server </summary>

</member>


-<member name="T:CarDealership.Models.CarBrand">

<summary>CarBrand entity </summary>

</member>


-<member name="P:CarDealership.Models.CarBrand.id">

<summary>CarBrand id </summary>

</member>


-<member name="P:CarDealership.Models.CarBrand.brand">

<summary>Brand property. </summary>

</member>


-<member name="P:CarDealership.Models.CarBrand.model">

<summary>Model property. </summary>

</member>


-<member name="F:CarDealership.Models.CarBrand.carBrands">

<summary>list of all the brands with models that are existing. </summary>

</member>


-<member name="M:CarDealership.Models.CarBrand.#ctor(System.String,System.String)">

<summary>Contructor. Registers a brand with model. </summary>

<param name="brand">eg. BMW, Audi...</param>

<param name="model">eg. i30, Duster...</param>

</member>


-<member name="M:CarDealership.Models.CarBrand.ReturnBrand(System.String,System.String)">

<summary>Returns the first CarBrand available. </summary>

</member>


-<member name="M:CarDealership.Models.CarBrand.IsNew(System.String,System.String)">

<summary>Check if a certain model is new. </summary>

</member>


-<member name="T:CarDealership.Models.Customer">

<summary>Customer entity. </summary>

</member>


-<member name="P:CarDealership.Models.Customer.id">

<summary>Customer id. </summary>

</member>


-<member name="P:CarDealership.Models.Customer.name">

<summary>Customer name. </summary>

</member>


-<member name="P:CarDealership.Models.Customer.birthDate">

<summary>Customer birthdate. </summary>

</member>


-<member name="F:CarDealership.Models.Customer.password">

<summary>Customer password </summary>

</member>


-<member name="F:CarDealership.Models.Customer.email">

<summary>Customer email. </summary>

</member>


-<member name="P:CarDealership.Models.Customer.phoneNum">

<summary>Customer phone number. </summary>

</member>


-<member name="F:CarDealership.Models.Customer.carsFavourite">

<summary>the cars(offers) that are wished by the user </summary>

</member>


-<member name="F:CarDealership.Models.Customer.customers">

<summary>List of customers </summary>

</member>


-<member name="F:CarDealership.Models.Customer.publicOffers">

<summary>the cars(offers) that are owned by the user </summary>

</member>


-<member name="F:CarDealership.Models.Customer.favoritedCars">

<summary>Customer's favotited cars. </summary>

</member>


-<member name="M:CarDealership.Models.Customer.#ctor(System.String,System.DateTime,System.String,System.String,System.String)">

<summary>Constructor </summary>

<param name="name"/>

<param name="birthDate"/>

<param name="password"/>

<param name="phoneNum"/>

<param name="email"/>

</member>


-<member name="T:CarDealership.Models.Picture">

<summary>Picture entity. </summary>

</member>


-<member name="P:CarDealership.Models.Picture.id">

<summary>Picture id </summary>

</member>


-<member name="P:CarDealership.Models.Picture.carId">

<summary>Car id </summary>

</member>


-<member name="P:CarDealership.Models.Picture.car">

<summary>Reference to class Car </summary>

</member>


-<member name="P:CarDealership.Models.Picture.picture">

<summary>picture direcory holder </summary>

</member>


-<member name="T:CarDealership.Models.RelationSeller">

<summary>RelationSeller class entity. </summary>

</member>


-<member name="P:CarDealership.Models.RelationSeller.id">

<summary>RelationSeller id </summary>

</member>


-<member name="P:CarDealership.Models.RelationSeller.customerId">

<summary>Customer id </summary>

</member>


-<member name="P:CarDealership.Models.RelationSeller.customer">

<summary>An instance of clsss Customer </summary>

</member>


-<member name="P:CarDealership.Models.RelationSeller.carId">

<summary>Car id </summary>

</member>


-<member name="P:CarDealership.Models.RelationSeller.car">

<summary>An instance of clsss Car </summary>

</member>


-<member name="T:CarDealership.Models.Car">

<summary>Car entity </summary>

</member>


-<member name="P:CarDealership.Models.Car.id">

<summary>Car id </summary>

</member>


-<member name="P:CarDealership.Models.Car.carBrandId">

<summary>CarBrand of the Car </summary>

</member>


-<member name="P:CarDealership.Models.Car.owner">

<summary>Owner of the car. </summary>

</member>


-<member name="P:CarDealership.Models.Car.price">

<summary>Price of the car. </summary>

</member>


-<member name="P:CarDealership.Models.Car.manufDate">

<summary>Date of manufacturing </summary>

</member>


-<member name="P:CarDealership.Models.Car.horsePower">

<summary>Horse power of the car. </summary>

</member>


-<member name="P:CarDealership.Models.Car.kmDriven">

<summary>Driven kilometers on the car. </summary>

</member>


-<member name="P:CarDealership.Models.Car.engineVolume">

<summary>Engine volume of the car. </summary>

</member>


-<member name="P:CarDealership.Models.Car.info">

<summary>Additional info about the car </summary>

</member>


-<member name="F:CarDealership.Models.Car.approvedCars">

<summary>List of all cars </summary>

</member>


-<member name="M:CarDealership.Models.Car.#ctor(CarDealership.Models.CarBrand,System.Double,System.String,System.Double,System.Double,System.Double,System.String)">

<summary>Constructor </summary>

<param name="carBrand"/>

<param name="price"/>

<param name="manufDateStr"/>

<param name="horsePower"/>

<param name="kmDriven"/>

<param name="engineVolume"/>

<param name="info"/>

</member>


-<member name="M:CarDealership.Models.Car.#ctor(System.String,System.String,System.Double,System.String,System.Double,System.Double,System.Double,System.String)">

<summary>Constructor </summary>

<param name="brand"/>

<param name="model"/>

<param name="price"/>

<param name="manufDateStr"/>

<param name="horsePower"/>

<param name="kmDriven"/>

<param name="engineVolume"/>

<param name="info"/>

</member>


-<member name="M:CarDealership.Models.Car.CarsFilterPrice(System.Double,System.Double,System.Collections.Generic.List{CarDealership.Models.Car})">

<summary>Filters car's in a certain range. </summary>

<param name="priceStart"/>

<param name="priceEnd"/>

<param name="cars"/>

<returns>A list of cars.</returns>

</member>


-<member name="M:CarDealership.Models.Car.PrintCarInfo">

<summary>Returns Car's Information </summary>

<returns>brand, model, date, year, price, seller, horsePower, km, engineVolume, addInfo, sellerPhone, sellerEmail</returns>

</member>


-<member name="T:CarDealership.App">

<summary>Provides application-specific behavior to supplement the default Application class. </summary>

</member>


-<member name="M:CarDealership.App.#ctor">

<summary>Initializes the singleton application object. This is the first line of authored codeexecuted, and as such is the logical equivalent of main() or WinMain(). </summary>

</member>


-<member name="M:CarDealership.App.OnLaunched(Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)">

<summary>Invoked when the application is launched normally by the end user. Other entry pointswill be used such as when the application is launched to open a specific file. </summary>

<param name="e">Details about the launch request and process.</param>

</member>


-<member name="M:CarDealership.App.OnNavigationFailed(System.Object,Windows.UI.Xaml.Navigation.NavigationFailedEventArgs)">

<summary>Invoked when Navigation to a certain page fails </summary>

<param name="sender">The Frame which failed navigation</param>

<param name="e">Details about the navigation failure</param>

</member>


-<member name="M:CarDealership.App.OnSuspending(System.Object,Windows.ApplicationModel.SuspendingEventArgs)">

<summary>Invoked when application execution is being suspended. Application state is savedwithout knowing whether the application will be terminated or resumed with the contentsof memory still intact. </summary>

<param name="sender">The source of the suspend request.</param>

<param name="e">Details about the suspend request.</param>

</member>


-<member name="M:CarDealership.App.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.App.GetXamlType(System.Type)">

<summary>GetXamlType(Type) </summary>

</member>


-<member name="M:CarDealership.App.GetXamlType(System.String)">

<summary>GetXamlType(String) </summary>

</member>


-<member name="M:CarDealership.App.GetXmlnsDefinitions">

<summary>GetXmlnsDefinitions() </summary>

</member>


-<member name="M:CarDealership.Views.ErrorMessage.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.ErrorMessage.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.ErrorMessage.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="M:CarDealership.Views.CarSearchMenue.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.CarSearchMenue.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.CarSearchMenue.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="F:CarDealership.Views.CarShowCase.buttNormalBrush">

<summary>color for when the car is unwished </summary>

</member>


-<member name="F:CarDealership.Views.CarShowCase.buttWishedBrush">

<summary>color for when the car is already wished </summary>

</member>


-<member name="M:CarDealership.Views.CarShowCase.GenerateImg">

<summary>make the image </summary>

</member>


-<member name="M:CarDealership.Views.CarShowCase.IsWished(System.Int32)">

<summary>checks if the car is already wished </summary>

<param name="option">0-check in db, 1-make wished, 2-unwished</param>

<returns/>

</member>


-<member name="M:CarDealership.Views.CarShowCase.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.CarShowCase.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.CarShowCase.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="M:CarDealership.Views.ListOfCars.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.ListOfCars.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.ListOfCars.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="M:CarDealership.Views.MainPanel.GenerateYear">

<summary>make the combo box data </summary>

</member>


-<member name="M:CarDealership.Views.MainPanel.GenerateMonths">

<summary>make monts combo box </summary>

</member>


-<member name="M:CarDealership.Views.MainPanel.GenerateDays(System.Int32)">

<summary>get the days in the month </summary>

<param name="month"/>

</member>


-<member name="M:CarDealership.Views.MainPanel.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.MainPanel.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.MainPanel.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="F:CarDealership.Views.MakeOffer.storageFiles">

<summary>all the files selected to be uploaded </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.MakeComboBoxes">

<summary>Adds all the neccessary elements to the comboBoxes </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.buttonAddPhoto_Click(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>ads photo to ready to be uploaded list </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.CarBrand_SelectionChanged(System.Object,Windows.UI.Xaml.Controls.SelectionChangedEventArgs)">

<summary>get the model based on the car </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.MakeOffer.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="M:CarDealership.Views.Search.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.Search.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.Search.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="M:CarDealership.Views.CarPage.GenerateImg(System.Int32)">

<summary>Manages the changing of images </summary>

<param name="mode">1-prevImg, 2-nextImg, 3-current</param>

</member>


-<member name="M:CarDealership.Views.CarPage.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.Views.CarPage.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.Views.CarPage.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="T:CarDealership.MainPage">

<summary>An empty page that can be used on its own or navigated to within a Frame. </summary>

</member>


-<member name="M:CarDealership.MainPage.AddCarPage(System.Object,Windows.UI.Xaml.Input.PointerRoutedEventArgs)">

<summary>event function to add car page from child class (show case) </summary>

</member>


-<member name="M:CarDealership.MainPage.AddListCars(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>event function to add list of cars from child class (search) </summary>

</member>


-<member name="M:CarDealership.MainPage.ResetView(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Called from other views, it resets the view deleting everything in MainView </summary>

</member>


-<member name="M:CarDealership.MainPage.toggleButtonMain_Checked(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Open the search by clicking the logo, used by most userControls </summary>

</member>


-<member name="M:CarDealership.MainPage.toggleButtonRegister_Checked(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Open the log in/sign up by clicking the register button </summary>

</member>


-<member name="M:CarDealership.MainPage.toggleButtonMakeOffer_Checked(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Open the MakeOffer by clicking the make offer button </summary>

</member>


-<member name="M:CarDealership.MainPage.toggleButtonWished_Checked(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Open the List of cars filled with wished cars by clicking the wished button </summary>

</member>


-<member name="M:CarDealership.MainPage.toggleButtonOwnOffers_Checked(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Open the List of cars filled with owned cars by clicking the owned button </summary>

</member>


-<member name="M:CarDealership.MainPage.ToggleSwitch_Toggled(System.Object,Windows.UI.Xaml.RoutedEventArgs)">

<summary>Toggle dark Mode </summary>

</member>


-<member name="M:CarDealership.MainPage.InitializeComponent">

<summary>InitializeComponent() </summary>

</member>


-<member name="M:CarDealership.MainPage.Connect(System.Int32,System.Object)">

<summary>Connect() </summary>

</member>


-<member name="M:CarDealership.MainPage.GetBindingConnector(System.Int32,System.Object)">

<summary>GetBindingConnector(int connectionId, object target) </summary>

</member>


-<member name="T:CarDealership.Program">

<summary>Program class </summary>

</member>


-<member name="T:CarDealership.CarDealership_XamlTypeInfo.XamlMetaDataProvider">

<summary>Main class for providing metadata for the app or library </summary>

</member>


-<member name="M:CarDealership.CarDealership_XamlTypeInfo.XamlMetaDataProvider.GetXamlType(System.Type)">

<summary>GetXamlType(Type) </summary>

</member>


-<member name="M:CarDealership.CarDealership_XamlTypeInfo.XamlMetaDataProvider.GetXamlType(System.String)">

<summary>GetXamlType(String) </summary>

</member>


-<member name="M:CarDealership.CarDealership_XamlTypeInfo.XamlMetaDataProvider.GetXmlnsDefinitions">

<summary>GetXmlnsDefinitions() </summary>

</member>

</members>

</doc>
