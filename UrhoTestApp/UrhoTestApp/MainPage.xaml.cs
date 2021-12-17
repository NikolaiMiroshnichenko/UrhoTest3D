using System;
using System.ComponentModel;
using Urho;
using Xamarin.Forms;

namespace UrhoTestApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private SceneHandler _urhoArea;
        private float _panCameraPositionX;
        private float _panCameraPositionY;
        private float _panCameraPositionZ;
        private float _panCameraRotationX;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _urhoArea = await HelloWorldUrhoSurface.Show<SceneHandler>(new Urho.ApplicationOptions(assetsFolder: null));
        }

        private void X_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var horizontalPosotion = e.NewValue;
            if (_urhoArea != null)
            {
                var oldYPosition = _urhoArea.CameraNode.Position.Y;
                var oldZPosition = _urhoArea.CameraNode.Position.Z;

                _urhoArea.CameraNode.Position = new Urho.Vector3((float)horizontalPosotion, oldYPosition, oldZPosition);
                GetCameraPositionsInfo();
            }
        }

        private void Y_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var verticalPosition = e.NewValue;
            if (_urhoArea != null)
            {
                var oldXPosition = _urhoArea.CameraNode.Position.X;
                var oldZPosition = _urhoArea.CameraNode.Position.Z;

                _urhoArea.CameraNode.Position = new Urho.Vector3(oldXPosition, (float)verticalPosition, oldZPosition);
                GetCameraPositionsInfo();
            }
        }

        private void Z_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var zPosition = e.NewValue;
            if (_urhoArea != null)
            {
                var oldXPosition = _urhoArea.CameraNode.Position.X;
                var oldYPosition = _urhoArea.CameraNode.Position.Y;

                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, oldYPosition, (float)zPosition);
                GetCameraPositionsInfo();
            }
        }

        //cicrle rotation
        private void X_Rotation_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var oldXPosition = _urhoArea.CameraNode.Position.X;

            //first quater
            if (e.NewValue <= 5)
            {
                
                _urhoArea.CameraNode.Rotation = new Quaternion((float)MathHelper.RadiansToDegrees((Math.Acos((5-e.NewValue)/5))),0,0);
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, GetYCoordinate(e.NewValue), (float)e.NewValue);
                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;

                var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();                
                rotationValueLabel.Text = xAngle.X.ToString();

                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }

            //second quater
            if ((e.NewValue >= 5) && (e.NewValue < 10))
            {
                var asd = _urhoArea.CameraNode.Rotation.ToEulerAngles();
               
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, GetYCoordinate(e.NewValue), (float)e.NewValue);
                _urhoArea.CameraNode.Rotation = new Quaternion((float)(180 -  MathHelper.RadiansToDegrees(Math.Acos((e.NewValue-5)/5))), 0, 0);

                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                rotationValueLabel.Text = xAngle.X.ToString();

                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }

            //third quater
            if ((e.NewValue >= 10) && (e.NewValue < 15))
            {
                _urhoArea.CameraNode.Rotation = new Quaternion((float)(270 - MathHelper.RadiansToDegrees((Math.Asin((15-e.NewValue) / 5)))), 0, 0);
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, -GetYCoordinate(20 - e.NewValue), (float)(20 - e.NewValue));

                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                rotationValueLabel.Text = xAngle.X.ToString();

                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }

            //forth quater
            if ((e.NewValue >= 15) && (e.NewValue <= 20))
            {
                _urhoArea.CameraNode.Rotation = new Quaternion((float)(360 - MathHelper.RadiansToDegrees((Math.Acos((e.NewValue-15) / 5)))), 0, 0);
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, -GetYCoordinate(20 - e.NewValue), (float)(20 - e.NewValue));

                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                rotationValueLabel.Text = xAngle.X.ToString();

                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }
        }

        //  rhombus rotation
        private void X_Rombus_Rotation_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var oldXPosition = _urhoArea.CameraNode.Position.X;
            var oldYPosition = _urhoArea.CameraNode.Position.Y;
            var oldZPosition = _urhoArea.CameraNode.Position.Z;

            if (e.NewValue < 5)
            {
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, (float)e.NewValue, (float)e.NewValue);
                _urhoArea.CameraNode.Rotation = new Quaternion((float)(e.NewValue*18) , 0, 0);
                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                rotationValueLabel.Text = xCircleRotation.ToString("n2");
                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }
            if ((e.NewValue > 5) && (e.NewValue < 10))
            {
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, (float)(10 - e.NewValue), (float)e.NewValue);
                _urhoArea.CameraNode.Rotation = new Quaternion((float)(e.NewValue*18), 0, 0);
                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                rotationValueLabel.Text = xCircleRotation.ToString("n2");
                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }
            if ((e.NewValue > 10) && (e.NewValue < 15))
            {
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, (float)(10 - e.NewValue), (float)(20 - e.NewValue));
                _urhoArea.CameraNode.Rotation = new Quaternion((float)e.NewValue * 18, 0, 0);
                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                rotationValueLabel.Text = xCircleRotation.ToString("n2");
                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }
            if (e.NewValue > 15)
            {
                _urhoArea.CameraNode.Position = new Vector3(oldXPosition, (float)(e.NewValue - 20), (float)(20 - e.NewValue));
                _urhoArea.CameraNode.Rotation = new Quaternion((float)e.NewValue * 18, 0, 0);
                var yPos = _urhoArea.CameraNode.Position.Y;
                var zPos = _urhoArea.CameraNode.Position.Z;
                var xCircleRotation = _urhoArea.CameraNode.Rotation.X;
                rotationValueLabel.Text = xCircleRotation.ToString("n2");
                sliderValueLabel.Text = sliderRotation.Value.ToString("n2");
                GetCameraPositionsInfo();
            }
        }

        private void Y_Rotation_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            {
                var oldYPosition = _urhoArea.CameraNode.Position.Y;

                //first quater
                if (e.NewValue <= 5)
                {
                    _urhoArea.CameraNode.Rotation = new Quaternion(0, (float)MathHelper.RadiansToDegrees((Math.Acos((5 - e.NewValue) / 5))), 0);
                    _urhoArea.CameraNode.Position = new Vector3(GetXCoordinate(e.NewValue), oldYPosition,  (float)e.NewValue);

                    var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                    rotationValueLabel.Text = xAngle.Y.ToString();

                    sliderValueLabel.Text = sliderRotationY.Value.ToString("n2");
                    GetCameraPositionsInfo();
                }

                //second quater
                if ((e.NewValue >= 5) && (e.NewValue < 10))
                {
                    var asd = _urhoArea.CameraNode.Rotation.ToEulerAngles();

                    _urhoArea.CameraNode.Position = new Vector3(GetXCoordinate(e.NewValue), oldYPosition,  (float)e.NewValue);
                    _urhoArea.CameraNode.Rotation = new Quaternion( 0, (float)(180 - MathHelper.RadiansToDegrees(Math.Acos((e.NewValue - 5) / 5))), 0);

                    var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                    rotationValueLabel.Text = xAngle.Y.ToString();

                    sliderValueLabel.Text = sliderRotationY.Value.ToString("n2");
                    GetCameraPositionsInfo();
                }

                //third quater
                if ((e.NewValue >= 10) && (e.NewValue < 15))
                {
                    _urhoArea.CameraNode.Rotation = new Quaternion( 0, (float)(270 - MathHelper.RadiansToDegrees((Math.Asin((15 - e.NewValue) / 5)))), 0);
                    _urhoArea.CameraNode.Position = new Vector3(-GetXCoordinate(20 - e.NewValue),oldYPosition,  (float)(20 - e.NewValue));

                    var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                    rotationValueLabel.Text = xAngle.Y.ToString();

                    sliderValueLabel.Text = sliderRotationY.Value.ToString("n2");
                    GetCameraPositionsInfo();
                }

                //forth quater
                if ((e.NewValue >= 15) && (e.NewValue <= 20))
                {
                    _urhoArea.CameraNode.Rotation = new Quaternion( 0, (float)(360 - MathHelper.RadiansToDegrees((Math.Acos((e.NewValue - 15) / 5)))), 0);
                    _urhoArea.CameraNode.Position = new Vector3(-GetXCoordinate(20 - e.NewValue), oldYPosition,  (float)(20 - e.NewValue));

                    var xAngle = _urhoArea.CameraNode.Rotation.ToEulerAngles();
                    rotationValueLabel.Text = xAngle.Y.ToString();

                    sliderValueLabel.Text = sliderRotationY.Value.ToString("n2");
                    GetCameraPositionsInfo();
                }
            }
        }

        private void SetCameraPanParameters()
        {
            _panCameraPositionX = _urhoArea.CameraNode.Position.X;
            _panCameraPositionY = _urhoArea.CameraNode.Position.Y;
            _panCameraPositionZ = _urhoArea.CameraNode.Position.Z;
            _panCameraRotationX = _urhoArea.CameraNode.Rotation.X;
        }

        private void Restart_Button_Clicked(object sender, EventArgs e)
        {
            _urhoArea.CameraNode.Position = new Vector3(0, 0, 0);
            _urhoArea.CameraNode.Rotation = new Quaternion(0, 0, 0);
            rotationValueLabel.Text = "0";
            SetCameraPanParameters();
            GetCameraPositionsInfo();
        }

        private float GetYCoordinate(double z)
        {
            var zCoord = (float)Math.Sqrt(z * (10-z));
            return zCoord;
        }

        private float GetXCoordinate(double z)
        {
            var xCoord = (float)Math.Sqrt(z * (10 - z));
            return - xCoord;
        }

        private void GetCameraPositionsInfo()
        {
            x_pos_label.Text = _urhoArea.CameraNode.Position.X.ToString("n2");
            y_pos_label.Text = _urhoArea.CameraNode.Position.Y.ToString("n2");
            z_pos_label.Text = _urhoArea.CameraNode.Position.Z.ToString("n2");
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

        }
    }
}
