	
rem docker run -v /myredis/conf:/usr/local/etc/redis --name myredis redis redis-server /usr/local/etc/redis/redis.conf

docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack

