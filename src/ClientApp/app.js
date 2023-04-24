/*
 * This file launches the application by asking Ext JS to create
 * and launch() the Application class.
 */
Ext.application({
    extend: 'ClientApp.Application',

    name: 'ClientApp',

    requires: [
        // This will automatically load all classes in the ClientApp namespace
        // so that application classes do not need to require each other.
        'ClientApp.*'
    ],

    // The name of the initial view to create.
    // mainView: 'ClientApp.view.main.Main'
});
