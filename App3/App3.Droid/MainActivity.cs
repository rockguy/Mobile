using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace App3.Droid
{
    [Activity(Label = "App3", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, TextureView.ISurfaceTextureListener
    {
        Android.Hardware.Camera _camera;
        TextureView _textureView;

        public void OnSurfaceTextureAvailable(
      Android.Graphics.SurfaceTexture surface, int w, int h)
        {

            _camera = Android.Hardware.Camera.Open();

            _textureView.LayoutParameters =
                   new FrameLayout.LayoutParams(w, h);


            try
            {
                _camera.SetPreviewTexture(surface);
                _camera.StartPreview();

            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool OnSurfaceTextureDestroyed(
Android.Graphics.SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());



            _textureView = new TextureView(this);
            _textureView.SurfaceTextureListener = this;

            SetContentView(_textureView);
            

        }
    }
}

