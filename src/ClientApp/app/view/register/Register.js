
Ext.define('ClientApp.view.register.Register',{
    extend: 'Ext.window.Window',
    xtype: 'register',

    requires: [
        'ClientApp.view.register.RegisterController',
        'ClientApp.view.register.RegisterModel'
    ],

    controller: 'register-register',
    viewModel: {
        type: 'register-register'
    },

    title: 'Register User',
    width: 500,
    height: 800,

    closable: false,
    autoShow: true,

    layout: 'fit',

    items: [{
        xtype: 'form',
        reference: 'registerform',
        layout: 'anchor',
        bodyPadding: 10,

        fieldDefaults: {
            allowBlank: false,
            anchor: '100%',
            msgTarget: 'side'
        },

        items: [{
            xtype: 'textfield',
            name: 'username',
            fieldLabel: 'User Name',
        }, {
            xtype: 'textfield',
            name: 'password',
            inputType: 'password',
            fieldLabel: 'Password',
        }, {
            xtype: 'textfield',
            name: 'repeatpassword',
            inputType: 'password',
            fieldLabel: 'Repeat Password',
        }, {
            xtype: 'textfield',
            name: 'firstname',
            fieldLabel: 'First Name',
        }, {
            xtype: 'textfield',
            name: 'lastname',
            fieldLabel: 'Last Name',
        }, {
            xtype: 'textfield',
            name: 'personalnumber',
            fieldLabel: 'Personal Number',
        }]
    }],

    buttons: [{
        text: 'Register',
        listeners: {
            click: 'onButtonRegisterClick'
        }
    }, {
        text: 'Login',
        listeners: {
            click: 'onButtonLoginClick'
        }
    }]
});
