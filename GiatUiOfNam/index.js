/**
 * @format
 */

import {AppRegistry} from 'react-native';
import App from './App';
import {name as appName} from './app.json';
import Login from './loginPage/login';
import LoginByPhone from './loginPage/loginByPhone'

AppRegistry.registerComponent(appName, () => LoginByPhone);
