using System;
using SwinGameSDK;
using GameFramework;
using System.Collections.Generic;

namespace GalacticAssault
{
    public class Menu : Entity
    {
        /*===========*/
        /* Constants */
        /*===========*/

        private const int WIDTH = 500;
        private const int BORDER = 5;
        private const int ITEM_PADDING = 16;
        private const int ITEM_MARGIN = 32;
        private const int ITEM_HEIGHT = 64;
        private const int SELECTOR_SIZE = 8;

        /*========*/
        /* Fields */
        /*========*/

        private int _selected = 0;
        private float _selectorY;

        /*============*/
        /* Properties */
        /*============*/
        
        public int ZOrder { get; } = 0;
        public string Name { get; }
        public Point2D Offset { get; set; }
        public List<Tuple<string,Action>> Items = new List<Tuple<string,Action>>();

        public int Selected
        {
            get => _selected;
            protected set => _selected = value > (Items.Count-1) ? 0 :
                                         value < 0 ? (Items.Count-1) :
                                         value;
        }

        private int Height
        {
            get => ITEM_HEIGHT * Items.Count;
        }

        private Point2D Position
        {
            get {
                Point2D p = new Point2D();
                p.X = SwinGame.ScreenWidth()/2 - WIDTH/2 + Offset.X;
                p.Y = SwinGame.ScreenHeight()/2 - Height/2 + Offset.Y;
                return p;
            }    
        }

        private float SelectorY
        {
            get => Position.Y + (ITEM_HEIGHT/2) - (SELECTOR_SIZE/2) + (ITEM_HEIGHT * Selected);
        }

        /*=============*/
        /* Constructor */
        /*=============*/

        public Menu(string name)
        {
            Name = name;
            Selected = 0;
            _selectorY = SelectorY;

            Point2D offset = new Point2D();
            offset.X = 0;
            offset.Y = 0;
            Offset = offset;
        }

        /*=========*/
        /* Methods */
        /*=========*/

        public void Update(EntityManager entities)
        {
            int selected = Selected;
            _selectorY = (float)Utilities.Lerp(_selectorY, SelectorY, 0.75);
            if (SwinGame.KeyTyped(KeyCode.vk_UP)) Selected--;
            if (SwinGame.KeyTyped(KeyCode.vk_DOWN)) Selected++;
            if (SwinGame.KeyTyped(KeyCode.vk_RETURN))
            {
                SwinGame.PlaySoundEffect("Select2");
                Items[Selected].Item2();
            }
            if (selected != Selected) SwinGame.PlaySoundEffect("Select1");
        }

        public void Render()
        {
            DrawContainer();
            DrawName();
            DrawItems();
            DrawSelector();
        }

        public void AddItem(string name, Action action)
        {
            Items.Add(Tuple.Create(name, action));
            _selectorY = SelectorY;
        }

        private void DrawContainer()
        {
            SwinGame.FillRectangle(
                Color.White,
                Position.X - BORDER,
                Position.Y - BORDER,
                WIDTH + BORDER*2,
                Height + BORDER*2
            );
            SwinGame.FillRectangle(
                Color.Black,
                Position.X,
                Position.Y,
                WIDTH,
                Height
            );
        }

        private void DrawName()
        {
            Font font = SwinGame.FontNamed("MenuFont");
            int width = SwinGame.TextWidth(font, Name);
            int height = SwinGame.TextHeight(font, Name);
            SwinGame.FillRectangle(
                Color.Black,
                Position.X + ITEM_MARGIN,
                Position.Y - height,
                width + ITEM_PADDING * 2,
                height
            );
            SwinGame.DrawText(
                Name,
                Color.White,
                font,
                Position.X + ITEM_PADDING + ITEM_MARGIN,
                Position.Y - height
            );
        }

        private void DrawItems()
        {
            Font font = SwinGame.FontNamed("MenuFont");
            for (int i=0; i<Items.Count; i++)
            {
                string item = Items[i].Item1;
                int height = SwinGame.TextHeight(font, item);
                int centerText = (ITEM_HEIGHT/2) - (height/2);
                SwinGame.DrawText(
                    item,
                    Color.White,
                    font,
                    Position.X + ITEM_MARGIN + ITEM_PADDING,
                    Position.Y + centerText + ITEM_HEIGHT * i
                );
            }
        }

        private void DrawSelector()
        {
            SwinGame.FillRectangle(
                Color.White,
                Position.X + ((ITEM_MARGIN+ITEM_PADDING)/2) - (SELECTOR_SIZE/2),
                _selectorY,
                SELECTOR_SIZE,
                SELECTOR_SIZE
            );
        }
    }
}
