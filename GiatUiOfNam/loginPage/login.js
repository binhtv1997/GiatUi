import React, { Component } from 'react';
import { View, Text, ImageBackground, StyleSheet } from 'react-native';
import { white } from 'ansi-colors';
const background = require('../image/login_background.png');
export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
    };
  }

  render() {

    return (
      <View style={{ flex: 1 }}>

        <ImageBackground style={styles.container} source={background}>
          <View style={{ flex: 1, alignItems: "center", paddingTop: '35%' }}>
            <View style={{ alignItems: "center", borderWidth: 1, borderColor: 'white', borderRadius: 15 }}>
              <Text style={{ color: 'white', fontSize: 54, padding: 10 }}>Laundry</Text>
            </View>

          </View>
          <View style={{
            flex: 1, alignItems: "center", paddingLeft: 10,
            paddingRight: 10, paddingBottom: '60%', borderTopColor: 'white',
            borderWidth: 1
          }}>
            <View style={{
              paddingLeft: '45%',
              paddingRight: '45%', paddingTop: '5%',
              borderWidth: 1
            }}>

            </View>
            <View style={{
              backgroundColor: 'green',
              width: 300, height: 60,
              borderWidth: 1
            }}>
              <Text style={{ alignItems: 'center', fontSize: 16, color: 'white', paddingTop: 15, paddingLeft: 55 }} >Login with phone number</Text>
            </View>
            <View style={{
              paddingLeft: '45%',
              paddingRight: '45%', paddingTop: '5%',
              borderWidth: 1
            }}></View>
            <View style={{
              backgroundColor: 'blue',
              width: 300, height: 60,
              borderWidth: 1
            }}>
              <Text style={{
                alignItems: 'center', fontSize: 16, color: 'white', paddingTop: 15, paddingLeft: 75
              }} >
                Login with Facebook
                </Text>
            </View>
          </View>
        </ImageBackground>

      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },

});