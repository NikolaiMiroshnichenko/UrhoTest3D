using System.ComponentModel;
using System.Threading.Tasks;
using Urho;
using Urho.Shapes;

namespace UrhoTestApp
{
    public class SceneHandler: Application, INotifyPropertyChanged
    {
        public Node CameraNode { get; set; }
        private Color _legColor;
        private Color _plainColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public SceneHandler(ApplicationOptions options) : base(options)
        {
        }

        protected override async void Start()
        {
            base.Start();
            _legColor = Color.FromHex("#cc5200");
            _plainColor = Color.FromHex("#cc5200");
            await  CreateTableModel();
        }

        private async Task CreateTableModel()
        {
            var scene = new Scene();
            var octree = scene.CreateComponent<Octree>();

            var zoneNode = scene.CreateChild("Zone");
            var zone = zoneNode.CreateComponent<Zone>();

            // Set same volume as the Octree, set a close bluish fog and some ambient light
            zone.SetBoundingBox(new BoundingBox(-1000.0f, 1000.0f));
            zone.AmbientColor = Color.FromHex("#131E4B");
            zone.FogColor = Color.FromHex("#131E4B");
            zone.FogStart = 100;
            zone.FogEnd = 300;


            //Table creation
            //first leg
            Node nodeleg1 = scene.CreateChild();
            nodeleg1.Position = new Vector3(-0.5f, 0, 4.5f);
            nodeleg1.Rotation = new Quaternion(0, 0, 0);
            nodeleg1.SetScaleSilent(new Vector3(0.3f, 1f,0.3f));

            var modelObjectLeg1 = nodeleg1.CreateComponent<Urho.Shapes.Cylinder>();
            modelObjectLeg1.Color = _legColor;


            //second leg
            Node nodeleg2 = scene.CreateChild();
            nodeleg2.Position = new Vector3(0.5f, 0, 4.5f);
            nodeleg2.Rotation = new Quaternion(0, 0, 0);
            nodeleg2.SetScaleSilent(new Vector3(0.3f, 1f, 0.3f));

            var modelObjectLeg2 = nodeleg2.CreateComponent<Urho.Shapes.Cylinder>();
            modelObjectLeg2.Color = _legColor;

            //third leg
            Node nodeleg3 = scene.CreateChild();
            nodeleg3.Position = new Vector3(-0.5f, 0, 5.5f);
            nodeleg3.Rotation = new Quaternion(0, 0, 0);
            nodeleg3.SetScaleSilent(new Vector3(0.3f, 1f, 0.3f));

            var modelObjectLeg3 = nodeleg3.CreateComponent<Urho.Shapes.Cylinder>();
            modelObjectLeg3.Color = _legColor;


            //forth leg
            Node nodeleg4 = scene.CreateChild();
            nodeleg4.Position = new Vector3(0.5f, 0, 5.5f);
            nodeleg4.Rotation = new Quaternion(0, 0, 0);
            nodeleg4.SetScaleSilent(new Vector3(0.3f, 1f, 0.3f));

            var modelObjectLeg4 = nodeleg4.CreateComponent<Urho.Shapes.Cylinder>();
            modelObjectLeg4.Color = _legColor;

            //box

            Node boxNode = scene.CreateChild();
            boxNode.Position = new Vector3(0, 0.5f, 5);
            boxNode.Rotation = new Quaternion(0, 0, 0);
            boxNode.SetScaleSilent(new Vector3(1.8f, 0.1f, 1.8f));
            var box = boxNode.CreateComponent<Box>();
            box.Color = _plainColor;

            //axes
            Node axeXNode = scene.CreateChild();
            axeXNode.Position = new Vector3(0, 0, 5);
            axeXNode.SetScaleSilent(new Vector3(50, 0.05f, 0.05f));
            var axeX = axeXNode.CreateComponent<Cylinder>();
            axeX.Color = Color.Yellow;

            Node axeYNode = scene.CreateChild();
            axeYNode.Position = new Vector3(0, 0, 5);
            axeYNode.SetScaleSilent(new Vector3(0.05f, 50, 0.05f));
            var axeY = axeYNode.CreateComponent<Cylinder>();
            axeY.Color = Color.Cyan;

            Node axeZNode = scene.CreateChild();
            axeZNode.Position = new Vector3(0, 0, 5);
            axeZNode.SetScaleSilent(new Vector3(0.05f, 0.05f, 50));
            var axeZ = axeZNode.CreateComponent<Cylinder>();
            axeZ.Color = Color.White;


            //  light & camera
            Node light = scene.CreateChild(name: "light");
            light.SetDirection(new Vector3(0.4f, -0.5f, 0.3f));
            light.CreateComponent<Light>();
            light.Position = new Vector3(0, 3, 0);

            Node light2 = scene.CreateChild(name: "light");
            light2.SetDirection(new Vector3(-0.4f, 0.5f, 0.3f));
            light2.CreateComponent<Light>();
            light2.Position = new Vector3(5, 0, 5);

            Node light3 = scene.CreateChild(name: "light");
            light3.SetDirection(new Vector3(0,0,0));
            light3.CreateComponent<Light>();
            light3.Position = new Vector3(2, 2, 3);

            CameraNode = scene.CreateChild(name: "camera");
            Camera camera = CameraNode.CreateComponent<Camera>();
            Renderer.SetViewport(0, new Viewport(scene, camera, null));
            CameraNode.Rotation = new Quaternion(0, 0, 0);
            CameraNode.Position = new Vector3(0, 0, 0);
        }
    }
}
