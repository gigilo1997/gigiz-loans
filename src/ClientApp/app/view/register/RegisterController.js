Ext.define('ClientApp.view.register.RegisterController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.register-register',

    onButtonRegisterClick: function(button) {
        var me = this;

        var form = this.lookup('registerform');

        form.submit({
            url: 'https://localhost:7000/api/User/RegisterUser',
            success: function(form, action) {
                var data = JSON.parse(action.response.responseText);

                me.getView().destroy();
                window.location.reload();
                Ext.create({
                    xtype:'login'
                });
            },
            failure: function(form, action) {

                if(action.response != null) {
                    var data = JSON.parse(action.response.responseText);
                    if(data != null) {
                        Ext.MessageBox.alert('Error', data.data.message);
                    } else {
                        Ext.MessageBox.alert('Error', action.response.statusText);
                    }
                }
            }
        })
    },

    onButtonLoginClick: function(button) {
        var me = this;

        me.getView().destroy();
        Ext.create({
            xtype:'login'
        });
    }
});
