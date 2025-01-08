Add Premissions to Android Manifest 

  <!-- Permissions -->
  <uses-permission android:name="android.permission.INTERNET" />
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
  <uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
  <uses-permission android:name="android.permission.READ_PHONE_STATE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />



Add Line to Repository Line to the Repository Section in baseProjecetTemplate.Gradle

maven 	{
       url "https://maven-android.solar-engine.com/repository/se_sdk_for_android/"
 	}


Add Dependencies to Dependencies Section in LauncherTemplate.Gradle

implementation 'com.reyun.solar.engine.oversea:solar-engine-core:1.2.9.1'
implementation 'com.reyun.solar.engine.oversea:solar-remote-config:1.2.9.1'
