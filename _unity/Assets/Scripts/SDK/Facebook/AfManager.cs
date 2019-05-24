using Gamelogic.Extensions;

public class AfManager : Singleton<AfManager>
{
    void Start()
    {
/* Mandatory - set your AppsFlyer’s Developer key. */
        AppsFlyer.setAppsFlyerKey("zcKrZYJWnrWWctCxcLNnyT");
/* For detailed logging */
/* AppsFlyer.setIsDebug (true); */
#if UNITY_IOS
        /* Mandatory - set your apple app ID
         NOTE: You should enter the number only and not the "ID" prefix */
        AppsFlyer.setAppID("1465179638");
        AppsFlyer.trackAppLaunch();
#elif UNITY_ANDROID
  /* Mandatory - set your Android package name */
  AppsFlyer.setAppID ("YOUR_ANDROID_PACKAGE_NAME_HERE");
  /* For getting the conversion data in Android, you need to add the "AppsFlyerTrackerCallbacks" listener.*/
  AppsFlyer.init ("YOUR_APPSFLYER_DEV_KEY","AppsFlyerTrackerCallbacks");
#endif
    }
}
