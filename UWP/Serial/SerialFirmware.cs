//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SerialTemplate;

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Windows.ApplicationModel;
using Windows.Foundation;

using Windows.UI.Core;

using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SerialTemplate
{
    /// <summary>
    /// Demonstrates how to connect to a Serial Device and respond to device disconnects, app suspending and resuming events.
    /// 
    /// To use this sample with your device:
    /// 1) Include the device in the Package.appxmanifest. For instructions, see Package.appxmanifest documentation.
    /// 2) Create a DeviceWatcher object for your device. See the InitializeDeviceWatcher method in this sample.
    /// </summary>
    public sealed partial class SerialFirmware : Page
    {
        private const String ButtonNameDisconnectFromDevice = "Disconnect from device";
        private const String ButtonNameDisableReconnectToDevice = "Do not automatically reconnect to device that was just closed";

        // Pointer back to the main page
        private MainPage rootPage = MainPage.Current;

        private ObservableCollection<String> listOfDevices;


        public SerialFirmware()
        {
            this.InitializeComponent();

            listOfDevices = new ObservableCollection<String>() { "default MCU Firmware","blink sample","motor control","function tests"};

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// 
        /// Create the DeviceWatcher objects when the user navigates to this page so the UI list of devices is populated.
        /// </summary>
        /// <param name="eventArgs">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs eventArgs)
        {
            // If we are connected to the device or planning to reconnect, we should disable the list of devices
            // to prevent the user from opening a device without explicitly closing or disabling the auto reconnect

            FirmwareListSource.Source = listOfDevices;
        }

        /// <summary>
        /// Unregister from App events and DeviceWatcher events because this page will be unloaded.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs eventArgs)
        {


        }

        /// <summary>
        /// Selects the item in the UI's listbox that corresponds to the provided device id. If there are no
        /// matches, we will deselect anything that is selected.
        /// </summary>
        /// <param name="deviceIdToSelect">The device id of the device to select on the list box</param>
        private void SelectDeviceInList(String deviceIdToSelect)
        {
            // Don't select anything by default.
            UploadFirmware.SelectedIndex = -1;
            List<String> firmware = new List<String>() { "blink", "MotorControl", "Camera" };
            for (int deviceListIndex = 0; deviceListIndex < firmware.Count; deviceListIndex++)
            {
                if (listOfDevices[deviceListIndex] == deviceIdToSelect)
                {
                    UploadFirmware.SelectedIndex = deviceListIndex;

                    break;
                }
            }
        }
 
        private async void UploadFirmware_Click(Object sender, RoutedEventArgs eventArgs)
        {
            var selection = UploadFirmware.SelectedItems;
            DeviceListEntry entry = null;

            if (selection.Count > 0)
            {
                var obj = selection[0];
                entry = (DeviceListEntry)obj;

                if (entry != null)
                {

                }
            }
        }

    }
}
