//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("SmartLight.Views.GraphicsFinanPage.xaml", "Views/GraphicsFinanPage.xaml", typeof(global::SmartLight.Views.GraphicsFinanPage))]

namespace SmartLight.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\GraphicsFinanPage.xaml")]
    public partial class GraphicsFinanPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label economia_label;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Microcharts.Forms.ChartView Grafico;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(GraphicsFinanPage));
            economia_label = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "economia_label");
            Grafico = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Microcharts.Forms.ChartView>(this, "Grafico");
        }
    }
}
