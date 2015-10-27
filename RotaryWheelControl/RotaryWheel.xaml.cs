// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RotaryWheelUserControl
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using RotaryWheelUserControl.Extensions;
    using RotaryWheelUserControl.Helpers;
    using Windows.UI;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    public partial class RotaryWheel : UserControl, INotifyPropertyChanged
    {
        private readonly ObservableCollection<PieSlice> _pieSlices = new ObservableCollection<PieSlice>();

        public event PropertyChangedEventHandler PropertyChanged;

        private Color _backgroundColor = Colors.Black;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { SetField(ref _backgroundColor, value); }
        }

        private Color _foregroundColor = Colors.White;
        public Color ForegroundColor 
        {
            get { return _foregroundColor; }
            set { SetField(ref _foregroundColor, value); }
        }

        private double _angle;
        public double Angle
        {
            get { return _angle; }
            set { SetField(ref _angle, value); }
        }

        private double _size;
        public double Size
        {
            get { return _size; }
            set
            {
                SetField(ref _size, value);

                Height = _size;
                Width = _size;
            }
        }

        private IList<string> _slices;
        public IList<string> Slices
        {
            get { return _slices; }
            set
            {
                var upper = value.Select(x => x.ToUpperInvariant()).ToList();
                SetField(ref _slices, upper);
                Draw();
            }
        }

        private bool _hideLabels;
        public bool HideLabels
        {
            get { return _hideLabels; }
            set
            {
                SetField(ref _hideLabels, value);
                foreach (var pieSlice in _pieSlices)
                {
                    pieSlice.HideLabel = value;
                }
            }
        }

        public string SelectedItemValue
        {
            get { return _selectedItem?.Label; }
        }

        private PieSlice _selectedItem;
        private PieSlice SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    SetField(ref _selectedItem, value);

                    var eventHandler = PropertyChanged;
                    eventHandler?.Invoke(this, new PropertyChangedEventArgs("SelectedItemValue"));
                }
            }
        }

        public RotaryWheel()
        {
            DataContext = this;
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                Draw();
                SelectedItem = _pieSlices.FirstOrDefault();

                if (SelectedItem != null)
                {
                    Angle = 360 - SelectedItem.Angle/2;
                }
            };

            _pieSlices.CollectionChanged += (sender, args) =>
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (PieSlice item in args.NewItems)
                        {
                            layoutSpinner.Children.Add(item);
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (PieSlice item in args.OldItems)
                        {
                            layoutSpinner.Children.Remove(item);
                        }
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        layoutSpinner.Children.Clear();
                        break;
                }
            };
        }

        private void Draw()
        {
            _pieSlices.Clear();

            gridRotateTransform.CenterX = this.RenderSize.Width/2;
            gridRotateTransform.CenterY = this.RenderSize.Height/2;

            var startAngle = 0;
            var color = BackgroundColor;

            if (Slices != null)
            {
                foreach (var slice in Slices)
                {
                    var sliceSize = 360/Slices.Count();

                    var pieSlice = new PieSlice
                    {
                        StartAngle = startAngle,
                        Angle = sliceSize,
                        Radius = Size/2,
                        BackgroundColor = color,
                        Label = slice,
                        ForegroundColor = ForegroundColor,
                        HideLabel = HideLabels,
                    };

                    _pieSlices.Add(pieSlice);

                    startAngle += sliceSize;
                    color = color.Lighten();
                }
            }
        }

        private void layoutRoot_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            storyBoard.Stop();

            Angle = QuadrantHelper.GetAngle(e.Position, RenderSize);
        }

        private void layoutRoot_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var angleFromYAxis = 360 - Angle;
            SelectedItem = _pieSlices
                .SingleOrDefault(p => p.StartAngle <= angleFromYAxis && (p.StartAngle + p.Angle) > angleFromYAxis);

            var finalAngle = SelectedItem.StartAngle + SelectedItem.Angle / 2;

            doubleAnimation.From = Angle;
            doubleAnimation.To = 360 - finalAngle;
            storyBoard.Begin();

            Angle = 360 - finalAngle;
        }

        private void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!value.Equals(field))
            {
                field = value;
                var eventHandler = PropertyChanged;
                eventHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}