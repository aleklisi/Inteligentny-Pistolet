-module(test).
-compile(export_all).

% cd("C:/Users/sebac/Documents/GitHub/Inteligentny-Pistolet/SmartGun/Dispatcher").

testf(Temp) ->
    if
        Temp > 27 -> a;
        Temp == 26 -> b;
        true -> c
    end.