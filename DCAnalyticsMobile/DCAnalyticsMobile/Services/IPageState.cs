using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.Models;
using Plugin.FilePicker.Abstractions;
using Plugin.Geolocator.Abstractions;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Location = Xamarin.Essentials.Location;

namespace DCAnalyticsMobile.Services
{
    public interface IPageState<T>
    {
        void OnResumePage(T o);
        void OnSleepPage();
        void OnRebound();
        void OnExit();
        void OnConfirm();
        void OnSaveDraft();
    }

    public interface PromptPageState : IPageState<object> { }
    public interface LocationPageState : PromptPageState { void OnLocationCollected(Location location); void OnEnableLocation(); void OnLocationIgnored(); }
    public interface ConfigurationPageState : PromptPageState { void OnPurchaseRoleSeleted(); void OnTrainingRoleSeleted(); void OnCertificationRoleSeleted(); void OnCertificationSelected(Certification certification); void OnFieldInspectionSelected(); }
    public interface QuestionairePageState : PromptPageState { void OnQuestionaireSelected(Questionaire questionaire); void OnCertificationSelected(Certification questionaire); void OnRetrieve();
        void OnCategorySelectedAsync(Category category);
    }
    public interface SelectPageState : IPageState<bool> { void OnDropDownOptionSelected(); }
    public interface PicturePageState : IPageState<bool> { void OnPictureSelected(AIImage image, MediaFile mediaFile); }
    public interface PageNavigation<T>
    {
        void OnProfileRequested();
    }
}
