import React, { Component } from 'react';
import { View, Text, Image, TextInput, KeyboardAvoidingView } from 'react-native';
const flag = require('../image/Flag.png');
var value = '+84';
export default class LoginByPhone extends Component {
    constructor(props) {
        super(props);
        this.state = {
        };
    }

    render() {
        return (
            <View style={{flex:1}}>

            <KeyboardAvoidingView style={{ flex: 1 }} behavior="padding" enabled>

                <View style={{ flex: 1, alignItems: "center" }}>
                    <View style={{ alignItems: "center", borderWidth: 1, borderColor: 'white', borderRadius: 15 }}>
                        <Text style={{ color: 'black', fontSize: 34, padding: 10 }}>Login By Phone</Text>
                    </View>

                </View>

                <View style={{
                    flex: 1, flexDirection: 'row', alignItems: "center",
                     borderColor: 'white',
                    borderWidth: 1
                }}>
                    <View style={{
                        width: '20%',
                        alignItems: 'center'
                    }}>
                        <Image style={{
                            resizeMode: 'contain', height: 50, width: 60
                        }}
                            source={flag} />


                    </View>

                    <View style={{
                        backgroundColor: 'powderblue',
                        width: '80%', height: 60,
                    }}>
                        <TextInput style={{
                            alignItems: 'center', paddingLeft: 9, paddingTop: 16,
                            fontSize: 24
                        }}
                            value={value}
                            keyboardType='numeric'
                            // onChangeText={(e) => this.validations(e)}
                            value={this.state.myNumber}
                        />

                    </View>



                </View>
                <View style={{
                    flex: 1, alignItems: "center", paddingLeft: 10,
                    paddingRight: 10, borderTopColor: 'red',
                }}>
                    <View style={{
                        backgroundColor: 'blue',
                        width: 300, height: 60,
                    }}>
                        <Text style={{
                            alignItems: 'center', fontSize: 34, color: 'white',
                            paddingTop: 5, paddingLeft: 68
                        }} >Send code</Text>
                    </View>
                </View>
            </KeyboardAvoidingView>
            </View>

        );
    }
}


