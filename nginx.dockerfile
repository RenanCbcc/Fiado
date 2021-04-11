FROM nginx:latest
RUN rm /etc/nginx/nginx.conf
COPY /nginx.conf /etc/nginx/nginx.conf
EXPOSE 80 443
ENTRYPOINT ["nginx"]
# Parametros extras para o entrypoint
CMD ["-g", "daemon off;"]
