using Plugin.Maui.CalendarStore;

namespace MauiCalendarStorePluginSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var calendars = await CalendarStore.Default.GetCalendars();

            foreach (var calendar in calendars)
            {
                await DisplayAlert("Calendars", $"{calendar.Name} ({calendar.Id})", "OK");
            }

            var events = await CalendarStore.Default.GetEvents(startDate: DateTimeOffset.Now.AddDays(-1), endDate: DateTimeOffset.Now.AddDays(1));
            
            foreach (var ev in events)
            {
                await DisplayAlert("Events", $"{ev.Title} ({ev.Id}) Start: {ev.StartDate}", "OK");
            }
        }
    }

}
