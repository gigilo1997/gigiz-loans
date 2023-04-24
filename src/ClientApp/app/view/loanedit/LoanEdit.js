Ext.define('ClientApp.view.loanedit.LoanEdit',{
    extend: 'Ext.window.Window',
    xtype: 'loanedit',

    requires: [
        'ClientApp.view.loanedit.LoanEditController',
        'ClientApp.view.loanedit.LoanEditModel',
        'Ext.window.MessageBox'
    ],

    controller: 'loanedit-loanedit',
    viewModel: {
        type: 'loanedit-loanedit'
    },

    title: 'Loan Edit',
    width: window.screen.width / 2,
    height: window.screen.height / 2,

    closable: false,
    autoShow: true,

    layout: 'fit',

    items: [{
        xtype: 'form',
        reference: 'loaneditform',
        layout: 'anchor',
        bodyPadding: 10,

        fieldDefaults: {
            allowBlank: false,
            anchor: '100%',
            msgTarget: 'side'
        },
        items: [
            {
                xtype: 'combobox',
                fieldLabel: 'Loan Type',
                name: 'type',
                store: {
                    fields: ['id', 'name'],
                    data: [
                        { id: 0, name: 'Fast' },
                        { id: 1, name: 'Auto' },
                        { id: 2, name: 'Installment' }
                    ]
                },
                displayField: 'name',
                valueField: 'id',
                editable: false,
                allowBlank: false
            },
            {
                xtype: 'numberfield',
                fieldLabel: 'Amount',
                name: 'amount',
                minValue: 0,
                allowBlank: false
            },
            {
                xtype: 'combobox',
                fieldLabel: 'Currency',
                name: 'currency',
                store: {
                    fields: ['id', 'name'],
                    data: [
                        { id: 0, name: 'GEL' },
                        { id: 1, name: 'USD' },
                        { id: 2, name: 'EUR' }
                    ]
                },
                displayField: 'name',
                valueField: 'id',
                editable: false,
                allowBlank: false
            },
            {
                xtype: 'numberfield',
                fieldLabel: 'Duration (days)',
                name: 'durationDays',
                minValue: 0,
                allowBlank: false
            },
            {
                xtype: 'numberfield',
                fieldLabel: 'Duration (months)',
                name: 'durationMonths',
                minValue: 0,
                allowBlank: false
            },
            {
                xtype: 'numberfield',
                fieldLabel: 'Duration (years)',
                name: 'durationYears',
                minValue: 0,
                allowBlank: false
            }
        ]
    }],

    buttons: [{
        text: 'Submit',
        listeners: {
            click: 'onButtonSubmitClick'
        }
    }, {
        text: 'Cancel',
        listeners: {
            click: 'onButtonCancelClick'
        }
    }]
});
