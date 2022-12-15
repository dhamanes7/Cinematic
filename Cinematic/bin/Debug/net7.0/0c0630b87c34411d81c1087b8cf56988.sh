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

ps 67593;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 67593 > /dev/null;
done;

for child in $(list_child_processes 67639);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/shubhamdhamane/Documents/cambrian/sem2/adv web/Final_project/Cinematic/Cinematic/bin/Debug/net7.0/0c0630b87c34411d81c1087b8cf56988.sh;
