FROM debian:bookworm-slim

WORKDIR /app

COPY docker-libs/ /usr/lib/x86_64-linux-gnu/
RUN ln -sf libicudata.so.70.1 /usr/lib/x86_64-linux-gnu/libicudata.so.70 \
    && ln -sf libicui18n.so.70.1 /usr/lib/x86_64-linux-gnu/libicui18n.so.70 \
    && ln -sf libicuuc.so.70.1 /usr/lib/x86_64-linux-gnu/libicuuc.so.70 \
    && ln -sf libgssapi_krb5.so.2.2 /usr/lib/x86_64-linux-gnu/libgssapi_krb5.so.2 \
    && ln -sf libstdc++.so.6.0.30 /usr/lib/x86_64-linux-gnu/libstdc++.so.6 \
    && ln -sf libz.so.1.2.11 /usr/lib/x86_64-linux-gnu/libz.so.1

COPY publish/ .

ENV ASPNETCORE_URLS=http://+:8080
ENV LD_LIBRARY_PATH=/usr/lib/x86_64-linux-gnu
EXPOSE 8080

ENTRYPOINT ["./Shopping"]
