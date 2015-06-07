#Coding Guidelines

* We use Pascal Casing for all fields except private fields. 
* Dont use '_' for naming.
* All files showing under Solution Explorer must be named with Pascal Casing.
* All XAML Pages should be in the Views folder , must end with Page and follow this format :
	
		ReasonableNamePage.xaml

* ViewModels must be under ViewModels folder , should contain it's View's name and must end with ViewModel.

		ReasonableNamePage > ReasonableNamePageViewModel
	
* All defined ViewModels in code behind must end with VM , must contain its View's name and must be readonly if it hasn't some problems with it.
	
		MainPage > private readonly mainPageVM = new MainPageViewModel();
	
* All Styles,DataTemplates,Converters etc. must be defined in App.xaml unless it has some page dependent code.
* Converters must be under Converters folder.
* All models must be under Eksi.Models Project.