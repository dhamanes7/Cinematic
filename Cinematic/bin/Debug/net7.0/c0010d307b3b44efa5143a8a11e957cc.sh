function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 26182;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 26182 > /dev/null;
done;

for child in $(list_child_processes 26185);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/shubhamdhamane/Documents/cambrian/sem2/adv web/Final_project/Cinematic/Cinematic/bin/Debug/net7.0/c0010d307b3b44efa5143a8a11e957cc.sh;
