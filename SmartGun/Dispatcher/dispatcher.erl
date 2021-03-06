-module(dispatcher).
-author('AleksanderLisiecki').
-export([start/0]).
-export([service/3]).

start() ->
   inets:start(httpd, [ 
      {modules, [ 
         mod_alias, 
         mod_auth, 
         mod_esi, 
         mod_actions, 
         mod_cgi, 
         mod_dir,
         mod_get, 
         mod_head, 
         mod_log, 
         mod_disk_log 
      ]}, 
      
      {port,8081}, 
      {server_name,"dispatcher"}, 
      {server_root,"C://tmp"}, 
      {document_root,"C://tmp/htdocs"}, 
      {erl_script_alias, {"/erl", [dispatcher]}}, 
      {error_log, "error.log"}, 
      {security_log, "security.log"}, 
      {transfer_log, "transfer.log"}, 
      
      {mime_types,[ 
         {"html","text/html"}, {"css","text/css"}, {"js","application/x-javascript"} ]} 
   ]). 
         
service(SessionID, _Env, _Input) ->
      io:fwrite("Recalled at ~p\n",[now()]),
      {ok, BeforeTable} = file:read_file("top.html"),
      {ok, Table} = file:read_file("table.html"),
      {ok, AfterTable} = file:read_file("bottom.html"),
      mod_esi:deliver(SessionID, [ 
      "Content-Type: text/html\r\n\r\n", binary_to_list(BeforeTable) ++ binary_to_list(Table) ++ binary_to_list(AfterTable) ]).